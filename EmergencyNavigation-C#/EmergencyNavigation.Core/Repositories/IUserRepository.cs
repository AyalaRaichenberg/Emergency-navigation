using EmergencyNavigation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetUsersList();
        public User AddUser(User user);
        public User GetUserById(long id);
        public User UpdateUser(User user);
        public void DeleteUser(long id);
        public bool CheckEmail(string email);
    }
}
