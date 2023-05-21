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
    public class CustomersController : Controller
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;

        }

        [HttpGet("GetAll")]

        public IActionResult Get()

        {
            var result = _customerService.GetAll();

            if (result.Success)

            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("Getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]

        public IActionResult Add(Customers customer)
        {
            var result = _customerService.Add(customer);

            if (result.Success)

            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]

        public IActionResult Delete(Customers customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //IActionResult http durumlarında kullanılır


        [HttpPost("Update")]

        public IActionResult Update(Customers customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
