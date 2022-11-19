using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Khudmadad_Backend.EfCore
{
    [Table("Roles")]
    public class Roles
    {
        [Key, Required]
        public int roleId { get; set; }
        public string role { get; set; }

        public List<Users> users { get; set; }
    }
}
