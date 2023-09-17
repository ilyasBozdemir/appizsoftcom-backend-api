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

        [Column("user_id")]
        public int UserId { get; set; }
        /// <summary>
        /// Kullanıcının rol kimliği.
        /// </summary>
        /// 
        [Column("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// Kullanıcının kullanıcı adı.
        /// </summary>
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// Kullanıcının e-posta adresi.
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının şifre hash'i.
        /// </summary>
        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Kullanıcının şifre salt'i.
        /// </summary>
        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Kullanıcının adı
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Kullanıcının soyadı
        /// </summary>
        [Column("last_name")]
        public string LastName { get; set; }

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