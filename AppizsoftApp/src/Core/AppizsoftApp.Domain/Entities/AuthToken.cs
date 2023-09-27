using AppizsoftApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppizsoftApp.Domain.Entities
{

    /// <summary>
    /// Kullanıcıların oturum bilgilerini temsil eden AuthToken sınıfı.
    /// </summary>

    [Table("auth_tokens")]
    public class AuthToken : BaseEntity
    {
        /// <summary>
        /// AuthToken öğesinin benzersiz kimliği.
        /// </summary>
        [Column("token_id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Kullanıcı kimliği (yabancı anahtar).
        /// </summary>
       [Column("user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Oturum açma tokeni.
        /// </summary>
        [Required]
        [Column("token")]
        public string Token { get; set; }

        /// <summary>
        /// Cihaz adı veya tanımı.
        /// </summary>
        /// 
        [Column("device_name")]
        public string DeviceName { get; set; }

        /// <summary>
        /// Oturum açma zamanı.
        /// </summary>
        /// 
        [Column("login_time")]
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// Oturum kapatma zamanı (null ise oturum açık).
        /// </summary>
        /// 
        [Column("logout_time")]
        public DateTime? LogoutTime { get; set; }

    }
}
