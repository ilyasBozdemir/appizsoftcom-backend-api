using AppizsoftApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppizsoftApp.Domain.Entities
{
    /// <summary>
    /// Kullanıcıları temsil eden sınıf.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Kullanıcının kullanıcı kimliği.
        /// </summary>

        public Guid UserId { get; set; }
        /// <summary>
        /// Kullanıcının rol kimliği.
        /// </summary>
        /// 


        /// <summary>
        /// Role ile ilişkiyi temsil eden navigasyon özelliği
        /// </summary>
        public Role Role { get; set; }
        public int RoleId { get; set; }

        /// <summary>
        /// Kullanıcının e-posta adresi.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının şifre hash'i.
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Kullanıcının şifre salt'i.
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Kullanıcının adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Kullanıcının soyadı
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Kullanıcının hesap oluşturma tarihi.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Kullanıcının son güncelleme tarihi.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Kullanıcının son oturum açma tarihi.
        /// </summary>
        public DateTime? LastLogin { get; set; }
    }
}