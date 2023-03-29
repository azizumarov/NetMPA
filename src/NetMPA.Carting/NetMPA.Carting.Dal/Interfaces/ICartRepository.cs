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
        Task<CartDao> Get(Guid id);
        Task<IEnumerable<CartDao>> GetAll();
        Task Add(CartDao cartDao);
        Task Update(CartDao cartDao);
    }
}
