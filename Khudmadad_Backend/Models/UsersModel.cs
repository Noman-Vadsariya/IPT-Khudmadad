namespace Khudmadad_Backend.Models
{
    public class UsersModel
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public string userName { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
        public string firstName { get; set; } = String.Empty;
        public string lastName { get; set; } = String.Empty;
        public string dob { get; set; } = String.Empty;

    }
}
