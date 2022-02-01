namespace BlazorTest.Identity.Web.Client.Services
{
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using BlazorTest.Identity.Web.Client.Interfaces;
    using BlazorTest.Identity.Web.Client.Models;

    public class AccountService : IAccountService
    {
        private readonly HttpClient httpClient;

        public AccountService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> CreateAccount(RegistrationModel registrationModel)
        {
            var response = await this.httpClient.PostAsJsonAsync("identity/sign-up", registrationModel);

            var userId = response.Content.ReadAsStringAsync().Result;

            return userId;
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var response = await this.httpClient.PostAsJsonAsync("identity/login", loginModel);

            var userId = response.Content.ReadAsStringAsync().Result;

            return userId;
        }
    }
}
