using Microsoft.AspNetCore.Mvc;

namespace CS330_PROJECT.Controllers
{
    [ApiController]
    [Authenticator]
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
        public IActionResult AddUser(User user)
        {
            var userAdd = new User()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
            };
            users.Add(userAdd);
            return Ok();
        }

        [HttpPut(Name = "ModifyUser")]
        public IActionResult ModifyUser(int id, User user)
        {
            var listUser = users.Where(x => x.Id == id);
            
            var userModify = new User()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
            };

            if (listUser == null)
            {
                userRepository.AddUser(userModify);
            } else
            {
                // Not sure how to add the user.
                userRepository.ModifyUser(id, userModify);
            }

            return Ok();

        }

        [HttpGet(Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {

            return Ok(userRepository.Users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(string id)

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