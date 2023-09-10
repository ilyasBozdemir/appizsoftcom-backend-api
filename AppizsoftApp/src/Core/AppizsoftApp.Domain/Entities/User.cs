using AppizsoftApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppizsoftApp.Domain.Entities
{
    /// <summary>
    /// Kullanıcıları temsil eden sınıf.
    /// </summary>
    [Table("users")]
    public class User : BaseEntity
    {
        /// <summary>
        /// Kullanıcının kullanıcı kimliği.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Kullanıcının rol kimliği.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Kullanıcının kullanıcı adı.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Kullanıcının e-posta adresi.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının şifre hash'i.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Kullanıcının tam adı.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Kullanıcının hesap oluşturma tarihi.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Kullanıcının son güncelleme tarihi.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Kullanıcının son oturum açma tarihi.
        /// </summary>
        public DateTime LastLogin { get; set; }
    }
}