using NetMPA.Carting.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Bll.Interfaces
{
    public interface ICartingService
    {
        Task<IEnumerable<Item>> GetCartItems(Guid cardId);
        Task AddItemToCart(Guid cardId, Item item);
        Task RemoveItemFromCart(Guid cardId, int itemId);
    }
}
