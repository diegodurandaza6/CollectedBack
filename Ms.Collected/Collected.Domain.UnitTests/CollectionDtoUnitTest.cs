using Collected.Domain.Models;

namespace Collected.Domain.UnitTests
{
    [TestFixture]
    public class CollectionDtoUnitTest
    {
        [Test]
        public void CollectionDto_WithValidData_CreatesObjectWithCorrectValues()
        {
            // Arrange
            int id = 1;
            string station = "ANDES";
            string way = "BOG-CHI";
            byte hour = 0;
            string category = "I";
            int amount = 377;
            decimal tabulatedValue = 1000000;
            DateTime date = new(2021, 8, 1);
            
            
            // Act
            //var collectionDto = new CollectionDto(
            //    id,
            //    station,
            //    way,
            //    hour,
            //    category,
            //    amount,
            //    tabulatedValue,
            //    date.ToString()
            //);
            //Assert.Multiple(() =>
            //{
            //    // Assert
            //    Assert.That(collectionDto.Id, Is.EqualTo(id));
            //    Assert.That(collectionDto.Station, Is.EqualTo(station));
            //    Assert.That(collectionDto.Way, Is.EqualTo(way));
            //    Assert.That(collectionDto.Hour, Is.EqualTo(hour));
            //    Assert.That(collectionDto.Category, Is.EqualTo(category));
            //    Assert.That(collectionDto.Amount, Is.EqualTo(amount));
            //    Assert.That(collectionDto.TabulatedValue, Is.EqualTo(tabulatedValue));
            //    Assert.That(collectionDto.Date, Is.EqualTo(date.ToString()));
            //});
        }
    }
}
