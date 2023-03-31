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
        private IDictionary<Guid, CartDao> cartDB;
        private IDictionary<int, ItemDao> itemDB;

        public ItemRepository(IDictionary<Guid, CartDao> cartDB, IDictionary<int, ItemDao> itemDB)
        {
            this.itemDB = itemDB;
            this.cartDB = cartDB;
        }        

        public Task Add(ItemDao itemDao)
        {
            return Task.Run(() => itemDB.Add(itemDao.Id, itemDao));
        }

        public Task<IEnumerable<ItemDao>> GetAll()
        {
            return Task.Run<IEnumerable<ItemDao>>(() => itemDB.Values);
        }

        public Task<ItemDao> Get(int id)
        {
            return Task.Run<ItemDao>(() => itemDB[id]);
        }

        public Task<IEnumerable<ItemDao>> GetByCartId(Guid id)
        {
            return Task.Run<IEnumerable<ItemDao>>(() => cartDB[id].Items);
        }

        public Task Update(ItemDao itemDao)
        {
            return Task.Run(() => itemDB[itemDao.Id] = itemDao);
        }
    }
}
