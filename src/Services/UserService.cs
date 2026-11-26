using RestSharp;
using DigisQaTest.Models;

namespace DigisQaTest.Services
{
    public class UserService
    {
        private readonly RestClient _client;

        public UserService(RestClient client)
        {
            _client = client;
        }

        public RestResponse GetUser(int userId)
        {
            var request = new RestRequest($"/users/{userId}", Method.Get);
            return _client.Execute(request);
        }

        public RestResponse CreateUser(CreateUserRequest body)
        {
            var request = new RestRequest("/users", Method.Post);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }
    }
}