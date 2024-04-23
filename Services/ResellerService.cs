using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;

namespace CarQuery__Test.Services
{
    public class ResellerService : BaseRepository, IResellerService
    {

        public ResellerService(AppDbContext context) : base(context)
        {
        }

        public bool CreateReseller(Reseller reseller)
        {
            try
            {
                _context.Resellers.Add(reseller);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool DeleteReseller(int id)
        {
            try
            {
                var existingReseller = _context.Resellers.Find(id);
                _context.Resellers.Remove(existingReseller);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Reseller> GetAllResellers()
        {
            return _context.Resellers.ToList();

        }

        public IEnumerable<Reseller> GetResellerById(int id)
        {
            var reseller = _context.Resellers.Find(id);
            yield return reseller; 
        }

        public IEnumerable<Reseller> UpdateReseller(int id, Reseller reseller) 
        {
            var existingReseller = _context.Resellers.Find(id);

            existingReseller.Name = reseller.Name;
            existingReseller.Address = reseller.Address; 

            _context.SaveChanges();

            yield return reseller;
        }

    }
}
