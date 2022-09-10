using Microsoft.AspNetCore.Mvc;

namespace CS330_PROJECT.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserManagementController : ControllerBase
    {
        public static int currentId = 0;
        private readonly ILogger<UserManagementController> logger;

        public UserManagementController(ILogger<UserManagementController> logger)
        {
            this.logger = logger;
        }

        List<User> users = new List<User>()
        {
            new User { Id = 0, Email = "bobi@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 1, Email = "jill@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 2, Email = "john@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 3, Email = "fred@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 4, Email = "sam@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 5, Email = "fran@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 6, Email = "bill@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 7, Email = "erin@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 8, Email = "tom@pickles.com", Password = "changeme", CreatedDate = DateTime.Now },
            new User { Id = 9, Email = "ron@pickles.com", Password = "changeme", CreatedDate = DateTime.Now }
        };

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            var userAdd = new User()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreatedDate = user.CreatedDate
            };
            users.Add(userAdd);
            return Ok();
        }

        public IActionResult GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault(t => t.Id == id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(t => t.Id == id);
            users.Remove(user);
            return Ok();
        }
    }
}