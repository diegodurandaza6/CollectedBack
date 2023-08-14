
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Collected.AdapterInHttp.Controllers.Version1;
using Collected.Application.Exceptions;
using Collected.Domain.IPortsIn;
using Collected.Domain.Models;

namespace Collected.AdapterInHttp.UnitTests
{
    [TestFixture]
    public class CollectedControllerUnitTest
    {
        
        private Mock<ICollectedService> _collectedServiceMock;
        private Mock<ILogger<CollectedController>> _loggerMock;
        private CollectedController _collectedController;
        private CollectionDto newCollectionDtoMock;

        [SetUp]
        public void Setup()
        {
            _collectedServiceMock = new Mock<ICollectedService>();
            _loggerMock = new Mock<ILogger<CollectedController>>();
            _collectedController = new CollectedController(_collectedServiceMock.Object, _loggerMock.Object);
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
        //public async Task CreateCollected_WithValidCollected_ReturnsCreatedStatus()
        //{
        //    // Arrange
        //    var collected = newCollectedDtoMock;

        //    // Act
        //    var result = await _collectedController.CreateCollected(collected) as StatusCodeResult;

        //    // Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        //}

        //[Test]
        //public async Task CreateCollected_WithInvalidCollected_ReturnsBadRequest()
        //{
        //    // Arrange
        //    _collectedController.ModelState.AddModelError("key", "error message");
        //    var collected = newCollectedDtoMock;

        //    // Act
        //    var result = await _collectedController.CreateCollected(collected) as BadRequestObjectResult;

        //    // Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
        //}

        //[Test]
        //public async Task CreateCollected_WithCustomException_ReturnsUnprocessableEntity()
        //{
        //    // Arrange
        //    var collected = newCollectedDtoMock;
        //    _collectedServiceMock.Setup(s => s.CreateCollected(collected)).Throws(new CustomException("Custom exception"));

        //    // Act
        //    var result = await _collectedController.CreateCollected(collected) as ObjectResult;

        //    // Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status422UnprocessableEntity));
        //}

        //[Test]
        //public async Task CreateCollected_WithGenericException_ReturnsInternalServerError()
        //{
        //    // Arrange
        //    var collected = newCollectedDtoMock;
        //    _collectedServiceMock.Setup(s => s.CreateCollected(collected)).Throws(new Exception("Generic exception"));

        //    // Act
        //    var result = await _collectedController.CreateCollected(collected) as ObjectResult;

        //    // Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
        //}

        [Test]
        public async Task GetCollected_WithValidParameters_ReturnsOk()
        {
            IEnumerable<CollectionDto?> response = new List<CollectionDto>
            {
                newCollectionDtoMock
            };

            _collectedServiceMock.Setup(s => s.GetCollected()).ReturnsAsync(response);

            // Act
            var result = await _collectedController.GetCollected() as OkObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

        [Test]
        public async Task GetCollected_WithInvalidParameters_ReturnsBadRequest()
        {
            _collectedController.ModelState.AddModelError("key", "error message");

            // Act
            var result = await _collectedController.GetCollected() as BadRequestObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
        }

        [Test]
        public async Task GetCollected_WithCustomException_ReturnsUnprocessableEntity()
        {
            _collectedServiceMock.Setup(s => s.GetCollected()).Throws(new CustomException("Custom exception"));

            // Act
            var result = await _collectedController.GetCollected() as ObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status422UnprocessableEntity));
        }

        [Test]
        public async Task GetCollected_WithGenericException_ReturnsInternalServerError()
        {
            _collectedServiceMock.Setup(s => s.GetCollected()).Throws(new Exception("Generic exception"));

            // Act
            var result = await _collectedController.GetCollected() as ObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
        }
    }
}
