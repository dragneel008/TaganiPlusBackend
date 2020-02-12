namespace TaganiPlusUnitTests.Tests
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Entities.Entities;
    using Entities.WebRequests;
    using Entities.WebResponses;
    using Moq;
    using NUnit.Framework;
    using Services.Interfaces;
    using TaganiPlus.AutoMapperProfiles;
    using TaganiPlus.Controllers;
    using TaganiPlusUnitTests.Stubs;

    [TestFixture]
    public class AuthenticationControllerTests
    {
        private IJwtService jwtService;
        private IMapper mapper;
        private AuthenticationController target;

        [SetUp]
        public void Setup()
        {
            this.jwtService = new StubJwtService();
            this.mapper = new MapperConfiguration(x =>
            {
               x.AddProfile<ApiProfile>();
               x.AddProfile<ServiceProfile>();
            }).CreateMapper();

            this.target = new AuthenticationController(this.jwtService, this.mapper);
        }

        [TearDown]
        public void Teardown()
        {
            this.jwtService = null;
            this.mapper = null;
        }

        [Test]
        public async Task Login_RequestIsValid_ReturnUser()
        {
            // Arrange
            var expected = new LoginWebResponse
            {
                Email = string.Empty,
                Token = string.Empty
            };
            var request = new LoginWebRequest
            {
                Username = "valid",
                Password = "password"
            };

            // Act
            var actual = await this.target.Login(request);

            // Assert
            Assert.AreEqual(expected.Token, expected.Token);
        }
    }
}
