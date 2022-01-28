using BlazorTest.Identity.Domain.Interfaces;

namespace BlazorTest.Identity.Domain.Entities
{
    public class ApplicationUser : IBaseEntity
    {
        public Guid Id
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string PasswordHash
        {
            get; set;
        }
    }
}
