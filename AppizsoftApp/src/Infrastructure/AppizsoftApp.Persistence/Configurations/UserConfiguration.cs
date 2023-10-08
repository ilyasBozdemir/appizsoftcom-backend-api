using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Persistence.Configurations
{
    using AppizsoftApp.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users"); // Veritabanı tablo adını belirle

            builder.HasKey(u => u.UserId); // Anahtar sütunu tanımla

            builder.Property(u => u.UserId)
                .HasColumnName("user_id"); // Sütun adını belirle

            builder.Property(u => u.RoleId)
                .HasColumnName("role_id"); // Sütun adını belirle

            builder.Property(u => u.Email)
                .HasColumnName("email"); // Sütun adını belirle

            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash"); // Sütun adını belirle

            builder.Property(u => u.PasswordSalt)
                .HasColumnName("password_salt"); // Sütun adını belirle

            builder.Property(u => u.Name)
                .HasColumnName("name"); // Sütun adını belirle

            builder.Property(u => u.LastName)
                .HasColumnName("last_name"); // Sütun adını belirle

            builder.Property(u => u.CreatedAt)
                .HasColumnName("created_at"); // Sütun adını belirle

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at"); // Sütun adını belirle

            builder.Property(u => u.LastLogin)
                .HasColumnName("last_login"); // Sütun adını belirle
        }
    }

}
