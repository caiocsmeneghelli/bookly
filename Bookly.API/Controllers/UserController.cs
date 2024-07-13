using Bookly.Application.Model.InputModels;
using Bookly.Application.Model.ViewModels;
using Bookly.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> Get(int idUser)
        {
            try
            {
                UserViewModel vwModel = await _userService.GetUserAsync(idUser);
                return Ok(vwModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("")]
        public async Task<IActionResult> Post(UserInputModel inputModel)
        {
            int idUser = await _userService.CreateUserAsync(inputModel);
            
            return CreatedAtAction(nameof(Get), idUser, inputModel);
        }
    }
}