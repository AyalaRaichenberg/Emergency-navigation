using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Repositories;
using EmergencyNavigation.Core.Services;

namespace EmergencyNavigation.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsersList()
        {
            return _userRepository.GetUsersList();
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public User GetUserById(long id)
        {
            return _userRepository.GetUserById(id);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public void DeleteUser(long id)
        {
            _userRepository.DeleteUser(id);
        }

        public User GetUserByEmail(string email)
        {
            List<User> users=GetUsersList();
            foreach (User user in users)
            {
                if(user.Email == email) return user;
            }
            return null;
        }
        public bool CheckEmail(string email)
        {
            List<User> users = GetUsersList();
            foreach (User user in users)
            {
                if (user.Email == email) return true;

            }
            return false;
        }
    }
}
