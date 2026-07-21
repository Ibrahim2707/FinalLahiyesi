using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.DTOs.AboutUs
{
    public class AboutUsGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Create { get; set; }
        public string Description { get; set; }
    }
}
