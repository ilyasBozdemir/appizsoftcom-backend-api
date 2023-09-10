using AppizsoftApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Interfaces.Repositories
{
    /// <summary>
    /// Genel bir IRepository arabirimi, CRUD işlemlerini (Oluştur, Oku, Güncelle, Sil) tanımlar.
    /// </summary>
    /// <typeparam name="TEntity">Varlık türünü temsil eden tür.</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Tüm varlıkları asenkron olarak alır.
        /// </summary>
        /// <returns>Varlıkların koleksiyonu.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Tüm varlıkları asenkron olarak alır.
        /// </summary>
        /// <returns>Varlıkların koleksiyonu.</returns>
        Task<IEnumerable<TEntity>> GetAll();


        /// <summary>
        /// Belirli bir varlığı ID'ye göre asenkron olarak alır.
        /// </summary>
        /// <param name="id">Aranan varlığın benzersiz kimliği.</param>
        /// <returns>Belirtilen varlık.</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Belirli bir varlığı ID'ye göre asenkron olarak alır.
        /// </summary>
        /// <param name="id">Aranan varlığın benzersiz kimliği.</param>
        /// <returns>Belirtilen varlık.</returns>
        Task<TEntity> GetById(int id);


        /// <summary>
        /// Yeni bir varlık ekler.
        /// </summary>
        /// <param name="entity">Eklenmek istenen varlık.</param>
        Task Add(TEntity entity);

        /// <summary>
        /// Yeni bir varlık ekler.
        /// </summary>
        /// <param name="entity">Eklenmek istenen varlık.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Varlığı günceller.
        /// </summary>
        /// <param name="entity">Güncellenmek istenen varlık.</param>
        Task Update(TEntity entity);

        /// <summary>
        /// Varlığı günceller.
        /// </summary>
        /// <param name="entity">Güncellenmek istenen varlık.</param>
        Task UpdateAsync(TEntity entity);


        /// <summary>
        /// Varlığı siler.
        /// </summary>
        /// <param name="entity">Silinmek istenen varlık.</param>
        Task Delete(TEntity entity);

        /// <summary>
        /// Varlığı siler.
        /// </summary>
        /// <param name="entity">Silinmek istenen varlık.</param>
        Task DeleteAsync(TEntity entity);
    }

}
