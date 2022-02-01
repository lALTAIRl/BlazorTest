namespace BlazorTest.Identity.Web.Client.Models
{
    public class LoginModel
    {
        public string Email
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public LoginModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
