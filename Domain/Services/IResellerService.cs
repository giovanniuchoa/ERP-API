using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface IResellerService
    {

        IEnumerable<Reseller> GetAllResellers(); 
        IEnumerable<Reseller> GetResellerById(int id);
        bool CreateReseller(Reseller reseller);
        IEnumerable<Reseller> UpdateReseller(int id, Reseller reseller);
        bool DeleteReseller(int id); 

    }
}
