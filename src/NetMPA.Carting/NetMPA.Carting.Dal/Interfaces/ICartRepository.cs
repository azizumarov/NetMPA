using NetMPA.Carting.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Dal.Interfaces
{
    public interface ICartRepository
    {
        Task<CartDao> GetAsync(Guid id);
        Task<IEnumerable<CartDao>> GetAllAsync();
        Task<CartDao> AddAsync(CartDao cartDao);
        Task UpdateAsync(CartDao cartDao);
    }
}
