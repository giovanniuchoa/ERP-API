using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Services 
{
    public class SaleService : BaseRepository, ISaleService
    {

        public SaleService(AppDbContext context) : base(context)
        {
        }

        public static Sale ValidateSale(Sale sale)
        {

            if (sale != null && sale.IdPerson != 0 && sale.IdCar != 0 && sale.IdReseller != 0 && sale.Price != 0)
            {
                return sale;
            }
            else
            {
                return null;
            }
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            try
            {

                var ret = ValidateSale(sale);

                if (ret != null)
                {
                    _context.Sales.Add(sale);
                    await _context.SaveChangesAsync();
                    return sale;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public async Task<bool> DeleteSaleAsync(int id)
        {
            try
            {
                var saleToDelete = await _context.Sales.FindAsync(id);
                if (saleToDelete == null)
                {
                    return false;
                }

                _context.Sales.Remove(saleToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o negócio.", ex);
            }
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task<Sale> UpdateSaleAsync(int id, Sale sale)
        {
            var ret = ValidateSale(sale);
            var existingSale = await _context.Sales.FindAsync(id);

            if (ret == null)
            {
                return null;
            }
            else if (existingSale == null)
            {
                return null;
            }
            else
            {
                existingSale.IdPerson = sale.IdPerson;
                existingSale.IdCar = sale.IdCar;
                existingSale.IdReseller = sale.IdReseller;
                existingSale.Price = sale.Price;

                _context.Sales.Update(existingSale);
                await _context.SaveChangesAsync();

                return sale;
            }
        }
    }
}
