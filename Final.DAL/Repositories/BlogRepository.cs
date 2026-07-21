using Final.Core.Entities;
using Final.Core.Repositories;
using Final.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Repositories
{
    public class BlogRepository:GenericRepository<Blog>,IBlogRepository
    {
        private readonly FinalDbContext _context;
        public BlogRepository(FinalDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
