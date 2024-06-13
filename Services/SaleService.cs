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

        public async Task<List<Sale>> GetSalesByAsync (DateTime? dthRegistroINI, DateTime? dthRegistroFIM, string? marcaCarro, int? idVendedor, decimal? precoINI, decimal? precoFIM)
        {
            try
            {
                var ret = await _context.GetSalesByAsync(dthRegistroINI, dthRegistroFIM, marcaCarro, idVendedor, precoINI, precoFIM);
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Sale ValidateSale(Sale sale)
        {

            if (sale != null && sale.Fk_IdClient != 0 && sale.Fk_IdSeller != 0 && sale.Fk_IdCar != 0 && sale.price != 0
                && sale.DthRegister != null)
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
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Seller)
                .Include(s => s.Car)
                .ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Seller)
                .Include(s => s.Car)
                .SingleOrDefaultAsync(s => s.idSale == id);
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
                existingSale.Fk_IdClient = sale.Fk_IdClient;
                existingSale.Fk_IdSeller = sale.Fk_IdSeller;
                existingSale.Fk_IdCar = sale.Fk_IdCar;
                existingSale.DthRegister = sale.DthRegister;
                existingSale.price = sale.price;

                _context.Sales.Update(existingSale);
                await _context.SaveChangesAsync();

                return existingSale;
            }
        }
    }
}
