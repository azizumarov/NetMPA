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

        public async Task<IEnumerable<Item>> GetCartItems(Guid cardId)
        {
            var items = await itemRepository.GetByCartId(cardId);
            return items.Select(item=> new Item() { Id = item.Id, Name = item.Name, Image = item.Image, Price = item.Price, Quantity = item.Quantity});

        }
        
        public async Task AddItemToCart(Guid cardId, Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (item.Id < 1) throw new ArgumentException("Id is Required");
            if (string.IsNullOrEmpty(item.Name)) throw new ArgumentException("Name is Required");

            var cartDao = await cartRepository.Get(cardId);

            if (cartDao == null)
            {
                await cartRepository.Add(new CartDao() {Id = cardId });
                cartDao = await cartRepository.Get(cardId);
            }

            var itemDao = new ItemDao() { Id = item.Id, Name = item.Name, Image = item.Image, Price = item.Price, Quantity = item.Quantity };
            cartDao.AddItem(itemDao);

            await cartRepository.Update(cartDao);            
        }

        public async Task RemoveItemFromCart(Guid cardId, int itemId)
        {
            var cartDao = await cartRepository.Get(cardId);

            if (cartDao == null) throw new ApplicationException($"Cart {cardId} not found");

            cartDao.DeleteItem(itemId);
            await cartRepository.Update(cartDao);            
        }

    }
}
