namespace Bookly.API.Controllers
{
    [ApiController]
    [RoutePrefix("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Fix: criar busca por id.
        [HttpPost("")]
        public async Task<IActionResult> Post(UserInputModel inputModel)
        {
            int idUser = await _userService.CreateUserAsync(inputModel);
            return Ok(idUser);
        }
    }
}