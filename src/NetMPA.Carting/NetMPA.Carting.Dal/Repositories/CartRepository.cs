using NetMPA.Carting.Dal.Interfaces;
using NetMPA.Carting.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Dal.Repositories
{
    public class CartRepository : ICartRepository
    {
        private IDictionary<Guid, CartDao> cartDB;

        public CartRepository(IDictionary<Guid, CartDao> cartDB)
        {
            this.cartDB = cartDB;
        }

        public Task Add(CartDao cartDao)
        {
            return new Task(() => cartDB.Add(cartDao.Id, cartDao));
        }

        public Task<IEnumerable<CartDao>> GetAll()
        {
            return new Task<IEnumerable<CartDao>>(() => cartDB.Values);
        }

        public Task<CartDao> Get(Guid id)
        {
            return new Task<CartDao>(() => cartDB[id]);
        }

        public Task Update(CartDao cartDao)
        {
            return new Task(() => cartDB[cartDao.Id] = cartDao);
        }
    }
}
