using NetMPA.Carting.Dal.Interfaces;
using NetMPA.Carting.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Dal.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Task<ItemDao> AddAsync(CartDao cartDao)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemDao>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemDao> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemDao>> GetByCartIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemDao cartDao)
        {
            throw new NotImplementedException();
        }
    }
}
