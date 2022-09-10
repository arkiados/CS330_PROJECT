using Microsoft.AspNetCore.Mvc;

namespace CS330_PROJECT.Controllers
{
    [ApiController]
    [Authenticator]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        public static int currentId = 0;

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
                users.Add(userModify);
            } else
            {
                // Not sure how to add the user.
                // users.Add(id, userModify);
            }

            return Ok();

        }

        [HttpGet(Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            return Ok(users[id]);
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