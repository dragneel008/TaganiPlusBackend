namespace TaganiPlus.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Entities.Entities;
    using Entities.WebRequests;
    using Entities.WebResponses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("api/account")]  
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtService jwtService;
        private readonly IMapper mapper;

        public AuthenticationController(IJwtService jwtService, IMapper mapper)
        {
            this.jwtService = jwtService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Login to the app.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        /// <remarks>
        /// This endpoint will generate a token for you to be authenticated.
        /// </remarks>
        /// <response code="201">Returns the email and token string.</response>
        /// <response code="401">If you don't have the correct credentials.</response>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
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

                response = Created("api/account/login", userWithToken);
            }

            return response;
        }
    }
}
