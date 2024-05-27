using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface IResellerService
    {

        Task<IEnumerable<Reseller>> GetAllResellersAsync();
        Task<Reseller> GetResellerByIdAsync(int id);
        Task<Reseller> CreateResellerAsync(Reseller reseller);
        Task<Reseller> UpdateResellerAsync(int id, Reseller reseller);
        Task<bool> DeleteResellerAsync(int id); 

    }
}
 