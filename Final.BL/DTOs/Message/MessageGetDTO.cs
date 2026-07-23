using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.DTOs.Message
{
    public class MessageGetDTO
    {
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
    }
}
