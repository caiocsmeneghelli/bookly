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

        [HttpGet("{idUser}")]
        public async Task<IActionResult> Get(int idUser)
        {
            try
            {
                UserViewModel vwModel = _userService.GetUserAsync(idUser);
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