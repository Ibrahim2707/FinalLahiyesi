using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.DTOs.Slider
{
    public class SliderCreateDTO
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IFormFile Image { get; set; }
        public string Link { get; set; }

    }
}
