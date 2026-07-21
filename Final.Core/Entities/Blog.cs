using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
