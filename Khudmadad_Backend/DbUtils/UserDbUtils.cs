using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Npgsql.Replication;

namespace Khudmadad_Backend.DbUtils
{
    public class UserDbUtils
    {
        private Ef_DataContext _context;

        public UserDbUtils(Ef_DataContext context)
        {
            _context = context;
        }

        public List<UsersModel>? GetUsers()
        {
            List<UsersModel> response = new List<UsersModel>();
            var userList = _context.users.ToList();

            if (userList == null)
                return null;

            else
            {
                userList.ForEach(row => response.Add(new UsersModel()
                {
                    userId = row.userId,
                    roleId = row.roleId,
                    userName = row.userName,
                    password = row.password,
                    firstName = row.firstName,
                    lastName = row.lastName,
                    dob = row.dob,
                    description = row.description,
                    phoneNumber = row.phoneNumber 
                }));

                return response;
            }
        }

        public void AddUser(UsersModel user)
        {
            Users u = new Users();
            u.userName = user.userName;
            u.roleId = user.roleId;
            u.firstName = user.firstName;
            u.lastName = user.lastName;
            u.password = user.password;
            u.dob = user.dob;
            u.description = user.description;
            u.phoneNumber = user.phoneNumber;

            _context.users.Add(u);
            _context.SaveChanges();
        }

        public UsersModel? GetUserById(int id)
        {
            UsersModel response = new UsersModel();
            var user = _context.users.Where(u => u.userId.Equals(id)).FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                response.userId = user.userId;
                response.roleId = user.roleId;
                response.firstName = user.firstName;
                response.lastName = user.lastName;
                response.userName = user.userName;
                response.password = user.password;
                response.dob = user.dob;
                response.description = user.description;
                response.phoneNumber = user.phoneNumber;

                return response;
            }
        }

        public UsersModel? GetUserByUsername(string userName)
        {
            UsersModel response = new UsersModel();
            var user = _context.users.Where(u => u.userName.Equals(userName)).FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                response.userId = user.userId;
                response.roleId = user.roleId;
                response.firstName = user.firstName;
                response.lastName = user.lastName;
                response.userName = user.userName;
                response.password = user.password;
                response.dob = user.dob;
                response.description = user.description;
                response.phoneNumber = user.phoneNumber;

                return response;
            }
        }

        public bool UpdateUser(UsersModel user)
        {
            var _u = _context.users.Where(o => o.userId.Equals(user.userId)).FirstOrDefault();
            if (_u == null)
                return false;
            else
            {
                _u.firstName = user.firstName;
                _u.lastName = user.lastName;
                _u.password = user.password;
                _u.description = user.description;
                _u.phoneNumber = user.phoneNumber;

                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteUser(UsersModel user)
        {
            var _u = _context.users.Where(u => u.userId.Equals(user.userId)).FirstOrDefault();
            if (_u == null)
                return false;
            else
            {
                _context.users.Remove(_u);
                _context.SaveChanges();
                return true;
            }

        }
    }
}
