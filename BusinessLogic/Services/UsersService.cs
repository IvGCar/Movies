using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public class UsersService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UsersService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<User> GetUsers()
        {
            return _repositoryManager.Users.GetAll().Select(x => new User()
            {
                Email = x.Email,
                Name = x.Name,
                UserId = x.UserId
            }).ToList();
        }

        public object CreateUser(UserSession user)
        {           

            var domainUser = new DomainModels.User()
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password
            };

            var nameAvailabile = _repositoryManager.Users.UserAvailable(domainUser);

            if(nameAvailabile == false)
            {
                throw new Exception("User Name already in use, please choose another");
            }
            else
            {
                var dbUser = _repositoryManager.Users.Add(domainUser);
                _repositoryManager.Save();

                return dbUser.ToDTO();
            }


        }

    }
}
