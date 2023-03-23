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
        Task<IEnumerable<Item>> GetCardItemsAsync(Guid cardId);
        Task<bool> AddItemToCardAsync(Guid cardId, Item item);
        Task<bool> RemoveItemFromCardAsync(Guid cardId, int itemId);
    }
}
