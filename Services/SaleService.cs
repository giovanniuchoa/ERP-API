using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Services 
{
    public class SaleService : BaseRepository, ISaleService
    {

        public SaleService(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Sale> GetSaleById(int id)
        {
            var sale = _context.Sales.Find(id);
            yield return sale;
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _context.Sales.ToList();
        }

        public bool CreateSale([FromBody] Sale sale)
        {
            try
            {
                _context.Sales.Add(sale);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Sale> UpdateSale(int id, Sale sale)
        {
            var existingSale = _context.Sales.Find(id);

            existingSale.IdPerson = sale.IdPerson;
            existingSale.IdCar = sale.IdCar;
            existingSale.IdReseller = sale.IdReseller;
            existingSale.Price = sale.Price;

            _context.SaveChanges();

            yield return sale;
        }

        public bool DeleteSale(int id)
        {
            try
            {
                var existingSale = _context.Sales.Find(id);
                _context.Sales.Remove(existingSale);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
