using CarQuery__Test.Data;
using CarQuery__Test.Domain.Services;

namespace CarQuery__Test.Services
{
    public class ResellerService : BaseRepository, IResellerService
    {

        public ResellerService(AppDbContext context) : base(context)
        {
        }

    }
}
