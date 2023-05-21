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
    public class RentalsController : Controller
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;

        }

        [HttpGet("GetAll")]

        public IActionResult Get()

        {
            var result = _rentalService.GetAll();

            if (result.Success)

            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("Getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]

        public IActionResult Add(Rentals rental)
        {
            var result = _rentalService.Add(rental);

            if (result.Success)

            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]

        public IActionResult Delete(Rentals rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //IActionResult http durumlarında kullanılır


        [HttpPost("Update")]

        public IActionResult Update(Rentals rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
