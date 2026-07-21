using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.DTOs.Blog
{
    public class BlogGetDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CategoryName { get; set; }
    }
}
