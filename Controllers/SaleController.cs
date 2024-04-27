using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
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
        public IEnumerable<Sale> GetAllSales()
        {
            var sales = _saleService.GetAllSales();
            return sales;
        }

        [HttpGet("{id}")] //Get Sale by id
        public IEnumerable<Sale> GetSale(int id)
        {
            var sale = _saleService.GetSaleById(id);
            return sale;
        }

        [HttpPost] //Create a new Sale
        public bool CreateSale([FromBody] Sale sale)
        {
            bool result = _saleService.CreateSale(sale);
            return result;
        }

        [HttpPut("{id}")] //Update a Sale
        public IEnumerable<Sale> UpdateSale(int id, [FromBody] Sale sale)
        {
            var newSale = _saleService.UpdateSale(id, sale);
            return newSale;
        }

        [HttpDelete("{id}")] //Delete a Sale
        public bool DeleteSale(int id)
        {
            bool result = _saleService.DeleteSale(id);
            return result;
        }
    }
}
