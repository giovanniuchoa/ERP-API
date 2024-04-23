using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Controllers
{
    [Route("Reseller")]
    public class ResellerController : ControllerBase
    {

        private readonly IResellerService _resellerService;

        public ResellerController(IResellerService ResellerService)
        {
            _resellerService = ResellerService;
        }

        [HttpGet] //Get all Resellers
        public IEnumerable<Reseller> GetAllResellers()
        {
            var resellers = _resellerService.GetAllResellers();
            return resellers;
        }

        [HttpGet("{id}")] //Get Reseller by id
        public IEnumerable<Reseller> GetReseller(int id)
        {
            var reseller = _resellerService.GetResellerById(id);
            return reseller;
        }

        [HttpPost] //Create a new Reseller
        public bool CreateReseller([FromBody] Reseller reseller)
        {
            bool result = _resellerService.CreateReseller(reseller);
            return result;
        }

        [HttpPut("{id}")] //Update a Reseller
        public IEnumerable<Reseller> UpdateReseller(int id, [FromBody] Reseller reseller)
        {
            var newReseller = _resellerService.UpdateReseller(id, reseller);
            return newReseller;
        }

        [HttpDelete("{id}")] //Delete a Reseller
        public bool DeleteReseller(int id)
        {
            bool result = _resellerService.DeleteReseller(id);
            return result;
        }

    }
}
