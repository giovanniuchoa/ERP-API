using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Controllers
{

    [Route("Sale")]
    public class SaleController : ControllerBase
    {

        private readonly ISaleService _saleService;

        public SaleController(ISaleService SaleService)
        {
            _saleService = SaleService;
        }

        [HttpGet] //Get all Sales
        public async Task<IActionResult> GetAllSales()
        { 
            try
            {
                var sales = await _saleService.GetAllSalesAsync();
                if (sales == null || !sales.Any())
                {
                    return NotFound("No sales found.");
                }
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")] //Get Sale by id
        public async Task<IActionResult> GetSale(int id)
        {
            try
            {
                var sale = await _saleService.GetSaleByIdAsync(id);
                if (sale == null)
                {
                    return NotFound($"Sale not found.");
                }
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost] //Create a new Sale
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            try
            {
                var createdSale = await _saleService.CreateSaleAsync(sale);
                if (createdSale == null)
                {
                    return BadRequest("Invalid JSON format");
                }
                else
                {
                    return Ok($"Sale created successfully.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")] //Update a Sale
        public async Task<IActionResult> UpdateSale(int id, [FromBody] Sale sale)
        {

            try
            {
                var updatedSale = await _saleService.UpdateSaleAsync(id, sale);
                if (updatedSale == null)
                {
                    return NotFound($"Failed to update sale.");
                }
                return Ok($"Sale updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")] //Delete a Sale
        public async Task<IActionResult> DeleteSale(int id)
        {
            try
            {
                var result = await _saleService.DeleteSaleAsync(id);
                if (result == false)
                {
                    return NotFound($"Sale not found.");
                }
                return Ok($"Sale ID ({id}) deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
