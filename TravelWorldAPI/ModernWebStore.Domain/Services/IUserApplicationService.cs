using ModernWebStore.Domain.Commands.UserCommands;
using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface IUserApplicationService
    {
        
            User Register(User user);
            User Authenticate(string email, string password);
            List<User> List();
        
    }
}
