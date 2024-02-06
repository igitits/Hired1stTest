using Hired1stTest.DTO;
using Hired1stTest.Models;

namespace Hired1stTest.Services.Interfaces
{
    public interface IUser
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserByEmail(string email);
        public bool CreateUser(RegisterDTO user);
        public int UpdateUser(User user);
        public int DeleteUser(string email);
        public User LoginUser(LoginDTO cred);
    }
}
