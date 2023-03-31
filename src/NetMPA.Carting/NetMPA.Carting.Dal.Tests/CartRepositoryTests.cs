using NetMPA.Carting.Dal.Interfaces;
using NetMPA.Carting.Dal.Models;
using NetMPA.Carting.Dal.Repositories;

namespace NetMPA.Carting.Dal.Tests
{
    public class CartRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CartRepository_Get()
        {
            //Arrange
            var cartDao = new CartDao() { Id = Guid.NewGuid() };
            var db = new Dictionary<Guid, CartDao>();
            db.Add(cartDao.Id, cartDao);

            var cartRepository = new CartRepository(db);

            //Act
            var result = await cartRepository.Get(cartDao.Id);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(CartDao), result);

            Assert.AreEqual(cartDao.Id, result.Id);
        }
    }
}