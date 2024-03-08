using CarQuery__Test.Services.Data;

namespace CarQuery__Test.Services
{
    public abstract class BaseRepository
    {

        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}
