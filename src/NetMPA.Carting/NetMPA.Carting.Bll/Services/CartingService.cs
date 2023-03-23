using NetMPA.Carting.Bll.Interfaces;
using NetMPA.Carting.Bll.Models;
using NetMPA.Carting.Dal.Interfaces;
using NetMPA.Carting.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Bll.Services
{
    public class CartingService : ICartingService
    {
        private readonly ICartRepository cartRepository;
        private readonly IItemRepository itemRepository;

        public CartingService(ICartRepository cartRepository, IItemRepository itemRepository)
        {
            this.cartRepository = cartRepository;
            this.itemRepository = itemRepository;
        }   

        public async Task<IEnumerable<Item>> GetCardItemsAsync(Guid cardId)
        {
            var items = await itemRepository.GetByCartIdAsync(cardId);
            return items.Select(item=> new Item() { Id = item.Id, Name = item.Name, Image = item.Image, Price = item.Price, Quantity = item.Quantity});

        }
        
        public async Task<bool> AddItemToCardAsync(Guid cardId, Item item)
        {
            if (item == null) throw new ArgumentNullException("Item");
            if (item.Id < 1) throw new ArgumentException("Id is Required");
            if (string.IsNullOrEmpty(item.Name)) throw new ArgumentException("Name is Required");

            try
            {
                var cartDao = await cartRepository.GetAsync(cardId);
                var itemDao = new ItemDao() { Id = item.Id, Name = item.Name, Image = item.Image, Price = item.Price, Quantity = item.Quantity };
                cartDao.AddItem(itemDao);

                await cartRepository.UpdateAsync(cartDao);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<bool> RemoveItemFromCardAsync(Guid cardId, int itemId)
        {
            var cartDao = await cartRepository.GetAsync(cardId);

            try
            {
                cartDao.DeleteItem(itemId);
                await cartRepository.UpdateAsync(cartDao);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
