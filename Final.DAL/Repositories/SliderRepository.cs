using Final.Core.Entities;
using Final.Core.Repositories;
using Final.DAL.Contexts;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Repositories
{
    public class SliderRepository :GenericRepository<Slider>, ISliderRepository
    {
        private readonly FinalDbContext _context;
        public SliderRepository(FinalDbContext context):base(context)
        {
            _context = context;
        }

        public Task GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
