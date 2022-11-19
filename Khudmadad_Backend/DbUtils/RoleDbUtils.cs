using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;

namespace Khudmadad_Backend.DbUtils
{
    public class RoleDbUtils
    {
        private Ef_DataContext _context;

        public RoleDbUtils(Ef_DataContext context)
        {
            _context = context;
        }

        public List<RolesModel>? GetRoles()
        {
            List<RolesModel> response = new List<RolesModel>();
            var roleList = _context.roles.ToList();

            if (roleList == null)
                return null;

            else
            {
                roleList.ForEach(row => response.Add(new RolesModel()
                {
                    roleId = row.roleId,
                    role = row.role
                }));

                return response;
            }
        }

        public void AddRole(RolesModel role)
        {
            Roles r = new Roles();
            r.roleId = role.roleId;
            r.role = role.role;

            _context.roles.Add(r);
            _context.SaveChanges();
        }
    }
}
