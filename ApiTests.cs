using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace DigisQaTest
{
    [TestFixture]
    public class ApiTests
    {
        private RestClient _client;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
        }

        // TEST 1: GET
        [Test]
        public void GetUser_ShouldReturnOkAndValidData()
        {
            // Arrange
            var request = new RestRequest("/users/1", Method.Get);

            // Act
            var response = _client.Execute(request);

            // Asserts
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code should be 200");
            
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            Assert.That((int)data.id, Is.EqualTo(1), "User ID should match");
            Assert.That((string)data.name, Is.Not.Null, "User name should not be empty");
        }

        // TEST 2: Data-Driven
        [TestCase(1, ExpectedResult = HttpStatusCode.OK)]
        [TestCase(5, ExpectedResult = HttpStatusCode.OK)]
        [TestCase(999, ExpectedResult = HttpStatusCode.NotFound)] // Negative case
        public HttpStatusCode GetUser_WithDifferentIds_ShouldReturnExpectedStatus(int userId)
        {
            // Arrange
            var request = new RestRequest($"/users/{userId}", Method.Get);

            // Act
            var response = _client.Execute(request);

            // Assert
            return response.StatusCode;
        }

        // TEST 3: POST
        [Test]
        public void CreateUser_ShouldReturnCreated()
        {
            // Arrange
            var request = new RestRequest("/users", Method.Post);
            var body = new { name = "Kirill Laptii", job = "QA Engineer" };
            request.AddJsonBody(body);

            // Act
            var response = _client.Execute(request);

            // Asserts
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code should be 201");
            Assert.That(response.Content, Is.Not.Null, "Response content should not be null");

            dynamic data = JsonConvert.DeserializeObject(response.Content!);
            Assert.That((string)data.name, Is.EqualTo("Kirill Laptii"), "Name should match the sent data");
        }
    }
}