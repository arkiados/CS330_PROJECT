using Microsoft.AspNetCore.Mvc;

namespace CS330_PROJECT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public static List<User> users = new List<User>();
        public static int currentId = 0;

        private readonly ILogger<UserManagementController> logger;

        public UserManagementController(ILogger<UserManagementController> logger,
        IUserRepository userRepository) 
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        [HttpPost(Name = "AddUser")]
        [Authenticator]

        [HttpPut(Name = "ModifyUser")]

        [HttpGet(Name = "GetAllUsers")]

        [HttpGet(Name = "GetUser")]

        [HttpDelete(Name = "DeleteUser")]

        [HttpGet]
        [Route("api/[controller]/login/{userEmail}/{userPassword}")]
        public dynamic Get(string email, string password)
        {
            var token = TokenHelper.GetToken(email, password);
            return new { Token = token };
        }
    }
}