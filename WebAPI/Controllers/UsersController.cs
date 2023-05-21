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
    public class UsersController : Controller
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet("GetAll")]

        public IActionResult Get()

        {
            var result = _userService.GetAll();

            if (result.Success)

            {
                return Ok(result);// 200 sunucuyla alakalı her şey yolunda demekdir
            }

            return BadRequest(result); // 400 sunucuyla alakalı bir hata demekdir
        }

        [HttpGet("Getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]

        public IActionResult Add(Users user)
        {
            var result = _userService.Add(user);

            if (result.Success)

            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]

        public IActionResult Delete(Users user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //IActionResult http durumlarında kullanılır


        [HttpPost("Update")]

        public IActionResult Update(Users user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
