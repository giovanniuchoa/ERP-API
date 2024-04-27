using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetAllSales();
        IEnumerable<Sale> GetSaleById(int id);
        bool CreateSale(Sale sale);
        IEnumerable<Sale> UpdateSale(int id, Sale sale);
        bool DeleteSale(int id);

    } 
}
