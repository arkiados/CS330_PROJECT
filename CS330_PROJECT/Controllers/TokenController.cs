using Microsoft.AspNetCore.Mvc;

namespace CS330_PROJECT.Controllers
{
    public class TokenRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // This should require SSL
        [HttpPost(Name = "TokenPost")]
        public dynamic TokenPost([FromBody] TokenRequest tokenRequest)
        {
            var token = TokenHelper.GetToken(tokenRequest.Email, tokenRequest.Password);
            return new { Token = token };
        }

        // This should require SSL
        [HttpGet(Name = "TokenGet")]
        public dynamic TokenGet(string email, string password)
        {
            var token = TokenHelper.GetToken(email, password);
            return new { Token = token };
        }
    }
}
