using NetMPA.Carting.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Dal.Interfaces
{
    public interface IItemRepository
    {
        Task<ItemDao> GetAsync(int id);

        Task<IEnumerable<ItemDao>> GetByCartIdAsync(Guid id);
        Task<IEnumerable<ItemDao>> GetAllAsync();
        Task<ItemDao> AddAsync(CartDao cartDao);
        Task UpdateAsync(ItemDao cartDao);
    }
}
