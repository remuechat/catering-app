using IMS.Domain.Entities.Financial.Promos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Interfaces
{
    public interface IPromoRepository
    {
        Task<Promo?> GetByIdAsync(int id);
        Task<IEnumerable<Promo>> GetAllAsync();
    }
}
