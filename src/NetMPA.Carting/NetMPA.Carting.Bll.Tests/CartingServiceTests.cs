using Moq;
using NetMPA.Carting.Bll.Interfaces;
using NetMPA.Carting.Bll.Models;
using NetMPA.Carting.Bll.Services;
using NetMPA.Carting.Dal.Interfaces;
using NetMPA.Carting.Dal.Models;
using NetMPA.Carting.Dal.Repositories;
using NUnit.Framework;

namespace NetMPA.Carting.Bll.Tests
{
    public class CartingServiceTests
    {
        private ICartingService cartingService;
        [SetUp]
        public void Setup()
        {
            var cartRepository = new Mock<ICartRepository>();

            cartRepository
                .Setup(x => x.Get(It.IsAny<Guid>()))
                .ReturnsAsync(new CartDao() { Id = Guid.NewGuid() });

            var itemRepository = new Mock<IItemRepository>();
            itemRepository
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(new ItemDao() { Id = 1 });

            this.cartingService = new CartingService(cartRepository.Object, itemRepository.Object);
        }

        [Test]
        public async Task CartingService_GetCartItems()
        {
            //Arrange

            //Act
            var result = await this.cartingService.GetCartItems(Guid.NewGuid());
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(IEnumerable<Item>), result);

        }

        [Test]
        public void CartingService_AddItemToCart_CheckItemNull()
        {
            //Arrange

            //Act
            var ex = Assert.ThrowsAsync<ArgumentNullException>( async () => await cartingService.AddItemToCart(Guid.NewGuid(), null));
            //Assert
            Assert.AreEqual("Value cannot be null. (Parameter 'item')", ex.Message);
        }

        [Test]
        public void CartingService_AddItemToCart_CheckItemIdLessThanOne()
        {
            //Arrange

            //Act
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await cartingService.AddItemToCart(Guid.NewGuid(), new Item() { Id = 0}));
            //Assert
            Assert.AreEqual("Id is Required", ex.Message);
        }

        [Test]
        public void CartingService_AddItemToCart_CheckItemName()
        {
            //Arrange

            //Act
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await this.cartingService.AddItemToCart(Guid.NewGuid(), new Item() { Id = 1 }));
            //Assert
            Assert.AreEqual("Name is Required", ex.Message);
        }

        [Test]
        public void CartingService_RemoveItemFromCart()
        {
            //Arrange

            var cartRepository = new Mock<ICartRepository>();

            cartRepository
                .Setup(x => x.Get(It.IsAny<Guid>()))
                .ReturnsAsync(() => null);

            var itemRepository = new Mock<IItemRepository>();

            var cartingService = new CartingService(cartRepository.Object, itemRepository.Object);
            var guid = Guid.NewGuid();
            //Act

            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await cartingService.RemoveItemFromCart(guid, 1));
            //Assert
            Assert.AreEqual($"Cart {guid} not found", ex.Message); 

        }
    }
}