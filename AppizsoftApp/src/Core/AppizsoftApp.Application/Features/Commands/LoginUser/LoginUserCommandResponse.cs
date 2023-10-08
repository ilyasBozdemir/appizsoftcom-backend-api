using AppizsoftApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Commands.LoginUser
{
    /// <summary>
    /// Kullanıcının oturum açma komutuna verilen yanıtın temel sınıfı.
    /// </summary>
    public class LoginUserCommandResponse { }

    /// <summary>
    /// Kullanıcının oturum açma işlemi başarılı olduğunda verilen yanıt sınıfı.
    /// </summary>
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        /// <summary>
        /// Kullanıcıya verilen erişim token'ını temsil eder.
        /// </summary>
        public Token Token { get; set; }
    }

    /// <summary>
    /// Kullanıcının oturum açma işlemi başarısız olduğunda verilen yanıt sınıfı.
    /// </summary>
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        /// <summary>
        /// Hata mesajını temsil eder.
        /// </summary>
        public string Message { get; set; }
    }

}
