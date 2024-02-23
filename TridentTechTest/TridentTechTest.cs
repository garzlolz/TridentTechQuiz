using System.Net.Http.Headers;
using System.Net.Http.Json;
using TridentTech.Models;

namespace TridentTechTest
{
    [TestClass]
    public class TridentTechTest
    {
        private const string BaseUrl = "https://localhost:7165/api/";
        private readonly HttpClient _client;

        public TridentTechTest()
        {
            _client = new HttpClient();

        }

        private async Task<string?> GetBearerTokenAsync()
        {
            var request = new LoginRequestModel
            {
                Account = "123qwe",
                Password = "123qwe"
            };

            var response = await _client.PostAsJsonAsync(BaseUrl + "Login?isTeacher=true", request);
            response.EnsureSuccessStatusCode();

            var loginResponse = await response.Content.ReadFromJsonAsync<ResultResponse<LoginResponseModel>>();
            return loginResponse?.Data?.Token;
        }

        [TestMethod]
        public async Task Post_AddTeacher_Returns200()
        {
            var request = new TeacherBaseModel
            {
                Account = RandomString(10),
                Password = RandomString(10),
                Name = RandomString(4),
                Email = RandomString(5) + "@example.com"
            };

            string? bearerToken = await GetBearerTokenAsync();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await _client.PostAsJsonAsync(BaseUrl + "teachers", request);
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async Task Post_AddTeacher_Returns401IfUnauthorized()
        {
            var request = new TeacherBaseModel
            {
                Account = "unauthorizedaccount",
                Password = "testpassword",
                Name = "Test Name",
                Email = "test@example.com"
            };

            var response = await _client.PostAsJsonAsync(BaseUrl + "teachers", request);
            Assert.AreEqual(401, (int)response.StatusCode);
        }


        [TestMethod]
        public async Task Post_AddTeacher_Returns400IfAccountExists()
        {
            var request = new TeacherBaseModel
            {
                Account = "existingaccount",
                Password = "testpassword",
                Name = "Test Name",
                Email = "test@example.com"
            };

            string? bearerToken = await GetBearerTokenAsync();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await _client.PostAsJsonAsync(BaseUrl + "teachers", request);
            Assert.AreEqual(400, (int)response.StatusCode);
        }


        static string RandomString(int length)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+<>?";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[r.Next(chars.Length)]).ToArray());
        }
    }
}