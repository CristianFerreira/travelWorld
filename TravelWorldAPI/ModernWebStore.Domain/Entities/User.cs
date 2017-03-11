
using ModernWebStore.Domain.Scopes;
using ModernWebStore.SharedKernel.Helpers;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Entities
{
    public class User
    {

        protected User() { }
        public User (string name, string email, string password, string link, bool isAdmin)
        {
            this.Name = name;
            this.Email = email;
            this.Password = StringHelper.Encrypt(password);
            this.Link = link;
            this.IsAdmin = isAdmin;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Link { get; private set; }
        public bool IsAdmin { get; private set; }

        public virtual ICollection<Post> posts { get; set; }

        public void Register()
        {
            this.RegisterUserScopeIsValid();
          
        }

        public void Authenticate(string email, string password)
        {
            this.AuthenticateUserScopeIsValid(email, password);      
        }


        public void GrantAdmin()
        {
            this.IsAdmin = true;
        }

        public void RevokeAdmin()
        {
            this.IsAdmin = false;
        }
    }
}
