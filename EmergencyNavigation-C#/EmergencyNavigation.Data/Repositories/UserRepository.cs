using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmergencyNavigation.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<User> GetUsersList()
        {
            return _dataContext.Users.Include(u => u.UsualLocal).ToList();
        }

        public User GetUserById(long id)
        {
            return _dataContext.Users.Find(id);
        }

        public User AddUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            User userById = GetUserById(user.Id);
            if (userById != null) { 
            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Password = user.Password;
            _dataContext.SaveChanges();
            return userById;
            }
          return null;
        }

        public void DeleteUser(long id)
        {
            User userById = GetUserById(id);
            if (userById != null)
            {
                _dataContext.Remove(userById);
                _dataContext.SaveChanges();
            }
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
