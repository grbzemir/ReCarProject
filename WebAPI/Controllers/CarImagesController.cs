using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase

    {
        ICarImagesService _carImageService;
        public CarImagesController(ICarImagesService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpPost("add")]


        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImages carImage)
        {
            var result = _carImageService.Add(file, carImage); //object null reference
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImages carImage)

        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarid")]

        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}