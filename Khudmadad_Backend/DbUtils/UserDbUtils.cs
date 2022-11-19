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
                    dob = row.dob
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

                return response;
            }
        }
    }
}
