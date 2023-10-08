using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppizsoftApp.Domain.Common
{

    /// <summary>
    /// Bu soyut sınıf, projenizdeki tüm varlık sınıflarının ortak özelliklerini içerir.
    /// </summary>
    public abstract class BaseEntity: IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        virtual public DateTime? UpdatedDate { get; set; }
    }
}
