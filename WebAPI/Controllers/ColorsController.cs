using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;

        }

        [HttpGet("GetAll")]

        public IActionResult Get()

        {
            var result = _colorService.GetAll();

            if (result.Success)

            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("Getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]

        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);

            if (result.Success)
           
            {
                return Ok(result);
            
            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]

        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //IActionResult http durumlarında kullanılır


        [HttpPost("Update")]

        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
