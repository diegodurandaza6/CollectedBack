using Collected.Application.UseCases;
using Moq;
using Collected.Domain.IPortsOut;
using Collected.Application.Exceptions;
using Collected.Domain.Models;

namespace Collected.Application.UnitTests
{
    [TestFixture]
    public class CollectedServiceUnitTest
    {
        private Mock<ICollectedRepository> _collectedRepositoryMock;
        private CollectedService _collectedService;
        private CollectionDto newCollectionDtoMock;

        [SetUp]
        public void Setup()
        {
            _collectedRepositoryMock = new Mock<ICollectedRepository>();
            //_collectedService = new CollectedService(_collectedRepositoryMock.Object);
            //newCollectionDtoMock = new CollectionDto(
            //    1,
            //    "ANDES",
            //    "BOG-CHI",
            //    0,
            //    "I",
            //    377,
            //    1000000,
            //    new DateTime(2021, 8, 1).ToString()
            //);
        }

        //[Test]
        //public async Task CreateCollected_WithValidCollected_CallsCreateCollectedInRepository()
        //{
        //    // Arrange
        //    var collected = newCollectionDtoMock;

        //    // Act
        //    await _collectedService.CreateCollected(collected);

        //    // Assert
        //    _collectedRepositoryMock.Verify(r => r.CreateCollected(collected), Times.Once);
        //}

        //[Test]
        //public void CreateCollected_WithInvalidCollected_ThrowsCustomException()
        //{
        //    // Arrange
        //    var collected = new CollectedDto(
        //        newCollectionDtoMock.CollectedNumber,
        //        newCollectionDtoMock.ExpeditionDate,
        //        12,
        //        newCollectionDtoMock.InsuredValue,
        //        newCollectionDtoMock.PlanName
        //    );

        //    // Act + Assert
        //    Assert.ThrowsAsync<CustomException>(() => _collectedService.CreateCollected(collected));
        //}

        [Test]
        public async Task GetCollected_WithValidParameters_CallsGetCollectedInRepository()
        {
            // Act
            await _collectedService.GetCollected();

            // Assert
            _collectedRepositoryMock.Verify(r => r.GetCollected(), Times.Once);
        }

        [Test]
        public void GetCollected_WithInvalidParameters_ThrowsCustomException()
        {
            // Act + Assert
            Assert.ThrowsAsync<CustomException>(() => _collectedService.GetCollected());
        }
    }
}
