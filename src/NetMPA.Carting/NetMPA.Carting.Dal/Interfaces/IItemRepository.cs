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
        Task<ItemDao> Get(int id);

        Task<IEnumerable<ItemDao>> GetByCartId(Guid id);
        Task<IEnumerable<ItemDao>> GetAll();
        Task Add(ItemDao itemDao);
        Task Update(ItemDao itemDao);
    }
}
