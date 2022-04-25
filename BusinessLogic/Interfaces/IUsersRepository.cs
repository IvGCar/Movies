using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IUsersRepository
    {
        public List<DomainModels.User> GetAll();

        public bool UserAvailable(DomainModels.User user);
        public DomainModels.User Add(DomainModels.User user);
        public DomainModels.User GetUser(DomainModels.User user);
    }
}
