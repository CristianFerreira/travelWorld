using ModernWebStore.Domain.Commands.UserCommands;
using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using System;
using System.Collections.Generic;

namespace ModernWebStore.ApplicationService
{
    public class UserApplication : ApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;


        public UserApplication(IUserRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public User Register(User user)
        {
            
            user.Register();
            _repository.Register(user);

            if (Commit())
                return user;

            return null;
        }

        public User Authenticate(string username, string password)
        {
            return _repository.Authenticate(username, password);
        }

        public List<User> List()
        {
            return _repository.List();
        }
    }
}
