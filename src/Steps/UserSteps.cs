using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using DigisQaTest.Services;
using DigisQaTest.Models;

namespace DigisQaTest.Steps
{
    public class UserSteps
    {
        private readonly UserService _userService;

        public UserSteps(UserService userService)
        {
            _userService = userService;
        }

        public UserModel GetUserAndVerify(int userId)
        {
            var response = _userService.GetUser(userId);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), "API returned non-200 status");
            return JsonConvert.DeserializeObject<UserModel>(response.Content!);
        }

        public dynamic CreateUserAndVerify(CreateUserRequest requestBody)
        {
            var response = _userService.CreateUser(requestBody);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created), "API returned non-201 status");
            return JsonConvert.DeserializeObject(response.Content!)!;
        }
    }
}