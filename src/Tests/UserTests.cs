using NUnit.Framework;
using RestSharp;
using System.Net;
using DigisQaTest.Services;
using DigisQaTest.Steps;
using DigisQaTest.Models;

namespace DigisQaTest.Tests
{
    [TestFixture]
    public class UserTests
    {
        private RestClient _client;
        private UserSteps _userSteps;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(BaseUrl);
            var userService = new UserService(_client);
            _userSteps = new UserSteps(userService);
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
        }

        [Test]
        public void GetUser_ShouldReturnValidData()
        {
            var user = _userSteps.GetUserAndVerify(1);
            Assert.That(user.Id, Is.EqualTo(1), "User ID does not match");
        }

        [Test]
        public void CreateUser_ShouldReturnCreatedData()
        {
            var newUser = new CreateUserRequest { Name = "Kirill Laptii", Job = "QA Engineer" };
            var createdUser = _userSteps.CreateUserAndVerify(newUser);
            Assert.That((string)createdUser.name, Is.EqualTo("Kirill Laptii"));
        }
    }
}