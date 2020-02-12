namespace TaganiPlus.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Entities.Entities;
    using Entities.WebRequests;
    using Entities.WebResponses;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("api/account")]  
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtService jwtService;
        private IMapper mapper;

        public AuthenticationController(IJwtService jwtService, IMapper mapper)
        {
            this.jwtService = jwtService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginWebRequest userInfo)
        {
            IActionResult response = Unauthorized();
            var user = await this.jwtService.AuthenticateUser(this.mapper.Map<Users>(userInfo));

            if (user != null)
            {
                var tokenString = this.jwtService.GenerateJSONWebToken(user);
                var userWithToken = new LoginWebResponse
                {
                    Email = user.Email,
                    Token = tokenString
                };

                response = Ok(userWithToken);
            }

            return response;
        }
    }
}
