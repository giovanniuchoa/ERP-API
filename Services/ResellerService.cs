using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Services
{
    public class ResellerService : BaseRepository, IResellerService
    {

        public ResellerService(AppDbContext context) : base(context)
        {
        }

        public static Reseller ValidateReseller(Reseller reseller)
        {

            if (reseller != null && !string.IsNullOrEmpty(reseller.nameReseller) && !string.IsNullOrEmpty(reseller.address) 
                && !string.IsNullOrEmpty(reseller.brand) && reseller.classification != null)
            {
                return reseller;
            }
            else
            {
                return null;
            }
        }

        public async Task<Reseller> CreateResellerAsync(Reseller reseller)
        {
            try
            {

                var ret = ValidateReseller(reseller);

                if (ret != null)
                {
                    _context.Resellers.Add(reseller);
                    await _context.SaveChangesAsync();
                    return reseller;
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

        public async Task<bool> DeleteResellerAsync(int id)
        {
            try
            {
                var resellerToDelete = await _context.Resellers.FindAsync(id);
                if (resellerToDelete == null)
                {
                    return false;
                }

                _context.Resellers.Remove(resellerToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Reseller.", ex);
            }
        }

        public async Task<IEnumerable<Reseller>> GetAllResellersAsync()
        {
            return await _context.Resellers.ToListAsync();
        }

        public async Task<Reseller> GetResellerByIdAsync(int id)
        {
            return await _context.Resellers.FindAsync(id);
        }

        public async Task<Reseller> UpdateResellerAsync(int id, Reseller reseller)
        {
            var ret = ValidateReseller(reseller);
            var existingReseller = await _context.Resellers.FindAsync(id);

            if (ret == null)
            {
                return null;
            }
            else if (existingReseller == null)
            {
                return null;
            }
            else
            {
                existingReseller.nameReseller = reseller.nameReseller;
                existingReseller.address = reseller.address;
                existingReseller.brand = reseller.brand;
                existingReseller.classification = reseller.classification;

                _context.Resellers.Update(existingReseller);
                await _context.SaveChangesAsync();

                return reseller;
            }
        }
    }
}
