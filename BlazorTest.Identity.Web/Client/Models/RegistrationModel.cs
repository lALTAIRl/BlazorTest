namespace BlazorTest.Identity.Web.Client.Models
{
    public class RegistrationModel
    {
        public string Email
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string Confirmation
        {
            get; set;
        }

        public RegistrationModel(string email, string password, string confirmation)
        {
            this.Email = email;
            this.Password = password;
            this.Confirmation = confirmation;
        }
    }
}
