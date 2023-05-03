using MegaMinds_WebApp.Models;

namespace MegaMinds_WebApp.Repositories
{
    public interface IUserRepository
    {
        public UserModel GetUserByIdAsync(int id);
        public IEnumerable<UserModel> GetAllUsersAsync();
        public int AddUserAsync(UserModel userModel);
        public int UpdateUserAsync(int id, UserModel userModel);
        public int DeleteUserAsync(int id);
    }
}
