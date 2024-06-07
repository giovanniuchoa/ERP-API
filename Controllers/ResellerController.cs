using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Controllers
{
    [Route("Reseller")]
    [Authorize]
    public class ResellerController : ControllerBase
    {

        private readonly IResellerService _resellerService;

        public ResellerController(IResellerService ResellerService)
        {
            _resellerService = ResellerService;
        }

        [HttpGet] //Get all Resellers
        public async Task<IActionResult> GetAllResellers()
        {
            try
            {
                var resellers = await _resellerService.GetAllResellersAsync();
                if (resellers == null || !resellers.Any())
                {
                    return NotFound("No resellers found.");
                }
                return Ok(resellers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")] //Get Reseller by id
        public async Task<IActionResult> GetReseller(int id)
        {
            try
            {
                var reseller = await _resellerService.GetResellerByIdAsync(id);
                if (reseller == null)
                {
                    return NotFound($"Reseller not found.");
                }
                return Ok(reseller);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost] //Create a new Reseller
        public async Task<IActionResult> CreateReseller([FromBody] Reseller reseller)
        {
            try
            {
                var createdReseller = await _resellerService.CreateResellerAsync(reseller);
                if (createdReseller == null)
                {
                    return BadRequest("Invalid JSON format");
                }
                else
                {
                    return Ok($"Reseller created successfully.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")] //Update a Reseller
        public async Task<IActionResult> UpdateReseller(int id, [FromBody] Reseller reseller)
        {
            try
            {
                var updatedReseller = await _resellerService.UpdateResellerAsync(id, reseller);
                if (updatedReseller == null)
                {
                    return NotFound($"Failed to update Reseller.");
                }
                return Ok($"Reseller updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")] //Delete a Reseller
        public async Task<IActionResult> DeleteReseller(int id)
        {
            try
            {
                var result = await _resellerService.DeleteResellerAsync(id);
                if (result == false)
                {
                    return NotFound($"Reseller not found.");
                }
                return Ok($"Reseller ID ({id}) deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
