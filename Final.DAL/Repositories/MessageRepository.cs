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
    public class MessageRepository: GenericRepository<Message>, IMessageRepository
    {
        private readonly FinalDbContext _context;
        public MessageRepository(FinalDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
