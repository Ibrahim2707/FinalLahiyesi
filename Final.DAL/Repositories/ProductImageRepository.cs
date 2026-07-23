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
    public class ProductImageRepository : GenericRepository<ProductImage>,IProductImageRepository
    {
        private readonly FinalDbContext _context;
        public ProductImageRepository(FinalDbContext context):base(context) 
        {
            _context = context;
        }

    }
}
