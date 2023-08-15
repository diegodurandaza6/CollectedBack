using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Collected.Application.Exceptions;
using Collected.Domain.IPortsIn;
using Collected.Domain.Models;

namespace Collected.AdapterInHttp.Controllers.Version1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    public class CollectedController : ControllerBase
    {
        private readonly ICollectedService _collectedService;
        private readonly ILogger<CollectedController> _logger;

        public CollectedController(
            ICollectedService collectedService,
            ILogger<CollectedController> logger
        )
        {
            _collectedService = collectedService;
            _logger = logger;
        }

        [HttpGet("GetCollected")]
        public async Task<IActionResult> GetCollected()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                IEnumerable<CollectionDto?>? response = await _collectedService.GetCollected();
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, $"GetCollected error: {ex.Message}");
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetCollected error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("GetReport")]
        public IActionResult GetReport()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                byte[] response = _collectedService.GetReport();
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, $"GetReport error: {ex.Message}");
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetReport error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor");
            }
        }

        [HttpGet("CreateCollected")]
        public async Task<IActionResult> CreateCollected()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _collectedService.CreateCollected();
                
                return Ok(new { msg = "ok" });
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, $"CreateCollected error: {ex.Message}");
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CreateCollected error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor");
            }
        }
    }
}
