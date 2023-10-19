
using AppizsoftApp.Application.CustomAttributes;
using AppizsoftApp.Application.Dtos.Configuration;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Interfaces.Services.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AppizsoftApp.Infrastructure.Services.Configurations
{

    public class ApplicationService : IApplicationService
    {
        Url _developmentUrl = new Url();


        public ApplicationService()
        {
            string launchSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Properties", "launchSettings.json");
            string jsonText = File.ReadAllText(launchSettingsPath);
            JObject launchSettings = JObject.Parse(jsonText);
            _developmentUrl.HttpUrl  = (string)launchSettings["profiles"]["http"]["applicationUrl"];
            _developmentUrl.HttpsUrl = (string)launchSettings["profiles"]["https"]["applicationUrl"];
            string pattern = @"https://(.*?);";
            Match match = Regex.Match(_developmentUrl.HttpsUrl, pattern);
            if (match.Success)
                _developmentUrl.HttpsUrl = "https://" + match.Groups[1].Value;
        }
        public ApiConfiguration GetAuthorizeDefinitionEndpoints(Type type)
        {
            ApiConfiguration apiConfiguration = new ApiConfiguration()
            {
                BaseUrl = new BaseUrl()
                {
                    DevelopmentUrl = _developmentUrl,
                    ProductionUrl = new Url()
                    {
                        HttpsUrl = "https://api.appizsoft.com/",
                        HttpUrl = "https://api.appizsoft.com/"
                    },
                    StagingUrl = new Url()
                    {
                        HttpsUrl = "https://staging-api.appizsoft.com/",
                        HttpUrl = "https://staging-api.appizsoft.com/"
                    }
                },
            };
            apiConfiguration.Headers.Add(new Header()
            {
                Name = "Authorization",
                Value = "Bearer {JWT_TOKEN}",
                Description = "Bearer (apiKey) JWT Authorization header using the Bearer scheme Name: Authorization In: header"
            });


            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t => typeof(ControllerBase).IsAssignableFrom(t));

            List<Application.Dtos.Configuration.Controller> _controllers = new List<Application.Dtos.Configuration.Controller>();

            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods().Where(m => m.GetCustomAttributes(typeof(AuthorizeDefinitionAttribute), true).Any());

                var routeAttribute = controller.GetCustomAttributes(typeof(RouteAttribute), true).FirstOrDefault() as RouteAttribute;
                var apiVersionAttribute = controller.GetCustomAttributes(typeof(ApiVersionAttribute), true).FirstOrDefault() as ApiVersionAttribute;

                var producesAttribute = controller.GetCustomAttributes(typeof(ProducesAttribute), true).FirstOrDefault() as ProducesAttribute;
                var consumesAttribute = controller.GetCustomAttributes(typeof(ConsumesAttribute), true).FirstOrDefault() as ConsumesAttribute;

                Application.Dtos.Configuration.Controller _controller = null;
                foreach (var action in actions)
                {
                    var attributes = action.GetCustomAttributes(true);
                    if (attributes != null)
                    {
                        if (apiVersionAttribute != null)
                        {
                            if (_controller == null)
                            {
                                apiConfiguration.Version = apiVersionAttribute?.Versions.FirstOrDefault() + "";
                            }
                        }

                        if (routeAttribute != null)
                        {
                            var template = routeAttribute.Template;
                            if (_controller == null)
                            {
                                _controller = new Application.Dtos.Configuration.Controller() { BasePath = $"/{template}/" };
                                _controllers.Add(_controller);
                            }
                        }


                        var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

                        if (authorizeDefinitionAttribute != null)
                        {
                            if (_controller == null)
                            {
                                _controller = new Application.Dtos.Configuration.Controller() { Name = authorizeDefinitionAttribute.Menu };
                                _controllers.Add(_controller);
                            }
                            else
                            {
                                _controller.Name = authorizeDefinitionAttribute.Menu;
                            }

                            Application.Dtos.Configuration.Action _action = new Application.Dtos.Configuration.Action()
                            {
                                ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType) + "",
                                Definition = authorizeDefinitionAttribute.Definition
                            };

                            var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;

                            if (httpAttribute != null)
                            {
                                _action.HttpType = httpAttribute.HttpMethods.First();
                                _action.Route = $"/{httpAttribute.Template}";
                            }
                            else
                            {
                                _action.HttpType = HttpMethods.Get;
                            }

                            _action.ContentType = "application/json; charset=utf-8";

                            ParameterInfo[] parameters = action.GetParameters();


                            foreach (ParameterInfo parameter in parameters)
                            {
                                string parameterName = parameter.Name;
                                Type parameterType = parameter.ParameterType;

                                Parameter _parameter = new();
                                _parameter.Name = parameterName;


                                if (parameterType.IsClass)
                                {
                                    PropertyInfo[] properties = parameterType.GetProperties();
                                    
                                    
                                    foreach (var property in properties)
                                    {
                                        string propertyName = property.Name;
                                        Type propertyType = property.PropertyType;
                                        string className = parameterType.FullName;
                                        _parameter.Type = className;
                                        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>))
                                        {
                                            Type[] typeArguments = propertyType.GetGenericArguments();

                                            if (typeArguments.Length > 0)
                                            {
                                                foreach (var typeArgument in typeArguments)
                                                {
                                                    if (typeArgument.IsEnum)
                                                    {

                                                        Type enumType = typeArgument;

                                                        Array enumValues = Enum.GetValues(enumType);

                                                        var props = new List<EnumProperty>();


                                                        foreach (var value in enumValues)
                                                        {
                                                            props.Add(new EnumProperty()
                                                            {
                                                                Name = Enum.GetName(enumType, value),
                                                                Value = value + ""
                                                            });

                                                        }

                                                        _parameter.Properties.Add(new Property()
                                                        {
                                                            Name = enumType.FullName,
                                                            Type = "Enum",
                                                            Properties = props

                                                        });
                                                    }


                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (propertyType.Namespace == "System" && propertyType.FullName == "System.String")
                                            {
                                               
                                            }
                                            else
                                            {
                                                _parameter.Properties.Add(new Property()
                                                {
                                                    Name = property.Name,
                                                    Type = property.PropertyType.FullName

                                                });
                                            }
                                        }
                                    }
                                }
                                else if (parameterType.IsValueType) {}
                                else if (parameterType.IsEnum) { }
                                else
                                {
                                    _parameter.Name = parameterName;
                                    string className = parameterType.FullName;
                                    _parameter.Type = className;
                                }
                                _action.Parameters.Add(_parameter);
                            }
                            _controller.Actions.Add(_action);
                        }
                    }
                }
            }
            apiConfiguration.Controllers = _controllers;
            return apiConfiguration;
        }
        public ApiConfiguration GetAllDefinitionEndpoints(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
