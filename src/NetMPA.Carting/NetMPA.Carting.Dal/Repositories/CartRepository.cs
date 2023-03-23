using NetMPA.Carting.Dal.Interfaces;
using NetMPA.Carting.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Dal.Repositories
{
    internal class CartRepository : ICartRepository
    {
        public Task<CartDao> AddAsync(CartDao cartDao)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartDao>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartDao> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CartDao cartDao)
        {
            throw new NotImplementedException();
        }
    }
}
