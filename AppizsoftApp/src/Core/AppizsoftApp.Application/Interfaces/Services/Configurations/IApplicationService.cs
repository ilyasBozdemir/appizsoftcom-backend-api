using AppizsoftApp.Application.Dtos.Configuration;

namespace AppizsoftApp.Application.Interfaces.Services.Configurations
{
    public interface IApplicationService
    {
        ApiConfiguration GetAuthorizeDefinitionEndpoints(Type type);
        ApiConfiguration GetAllDefinitionEndpoints(Type type);
    }
}
