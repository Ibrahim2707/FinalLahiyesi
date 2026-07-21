using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.DTOs.Blog
{
    public class BlogUpdateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
