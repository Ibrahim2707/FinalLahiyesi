using Final.BL.DTOs.Product;
using Final.BL.DTOs.Slider;
using Final.BL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _service):ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas = await _service.GetAllAsync();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDTO dto)
        {
            var data = await _service.CreateAsync(dto);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ProductUpdateDTO dto)
        {
            var data = await _service.UpdateAsync(id, dto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("images/{Id}")]
        public async Task <IActionResult>DeleteImage(int Id)
        {
            await _service.DeleteAsync(Id);
            return Ok("Delete");
        }
    }
}
