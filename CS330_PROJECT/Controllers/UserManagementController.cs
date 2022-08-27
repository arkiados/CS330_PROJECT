using Microsoft.AspNetCore.Mvc;

namespace CS330_PROJECT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private IUserRepository userRepository;
        public static List<User> users = new List<User>();
        public static int currentId = 0;

        private readonly ILogger<UserManagementController> logger;

        public UserManagementController(ILogger<UserManagementController> logger,
        IUserRepository userRepository) 
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        [Authenticator]
        [HttpPost(Name = "AddUser")]
        public IActionResult AddUser()
        {

            return Ok();
        }

        [HttpPut(Name = "ModifyUser")]
        public IActionResult ModifyUser()
        {

            return Ok();
        }

        [HttpGet(Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {

            return Ok(userRepository.Users);
        }

        [HttpGet(Name = "GetUser")]
        public IActionResult GetUser()
        {

            return Ok();
        }


        [HttpDelete(Name = "DeleteUser")]
        public IActionResult DeleteUser()
        {

            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/login/{userEmail}/{userPassword}")]
        public dynamic Get(string email, string password)
        {
            var token = TokenHelper.GetToken(email, password);
            return new { Token = token };
        }
    }
}