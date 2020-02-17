namespace TaganiPlusUnitTests.Stubs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Entities;
    using Services.Interfaces;

    public class StubJwtService : IJwtService
    {
        private Dictionary<string, Users> stringUsers = new Dictionary<string, Users>();

        public StubJwtService()
        {
            this.stringUsers.Add(
                "valid",
                new Users
                {
                    Id = Guid.NewGuid(),
                    Password = "password",
                    Email = "valid"
                });
        }

        public Task<Users> AuthenticateUser(Users login)
        {
            if (login.Email == "valid")
            {
                return Task.FromResult(this.stringUsers["valid"]);
            }

            return null;
        }

        public string GenerateJSONWebToken(Users userInfo)
        {
            return string.Empty;
        }
    }
}
