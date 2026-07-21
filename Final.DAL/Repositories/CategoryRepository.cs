using Final.DAL.Contexts;
using Final.Core.Entities;
using Final.Core.Repositories;
namespace Final.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly FinalDbContext _context;
        public CategoryRepository(FinalDbContext context) : base(context)
        {
            _context = context;
        }
    }

    
}
