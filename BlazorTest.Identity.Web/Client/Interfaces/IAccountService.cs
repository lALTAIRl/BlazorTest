namespace BlazorTest.Identity.Web.Client.Interfaces
{
    using BlazorTest.Identity.Web.Client.Models;

    public interface IAccountService
    {
        Task<string> CreateAccount(RegistrationModel registrationModel);

        Task<string> Login(LoginModel loginModel);
    }
}
