using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appizsoft.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost("api/auth/login")]
        public IActionResult Login(string email, string passw)
        {
            return Ok();
        }
        [HttpPost("api/auth/logout")]
        [Authorize] // Sadece oturum açmış kullanıcılar için erişilebilir
        public IActionResult Logout()
        {
            return Ok(new { message = "Oturum başarıyla sonlandırıldı." });
        }

        [HttpPost("api/auth/forgotpassword")]
        public IActionResult ForgotPassword()
        {

            return Ok(new { message = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi." });
        }
        [HttpPost("api/auth/resetpassword")]
        public IActionResult ResetPassword()
        {
            return Ok(new { message = "Şifreniz başarıyla sıfırlandı." });

        }
    }
}
