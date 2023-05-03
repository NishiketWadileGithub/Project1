using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MegaMinds_WebApp.Data;
using MegaMinds_WebApp.Models;


namespace MegaMinds_WebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserModel> GetAllUsersAsync()
        {
            var users = _dbContext.Users
                .FromSqlRaw("EXECUTE dbo.GetAllUsers")
                .AsEnumerable()
                .ToList();

            return users;
        }

        public UserModel GetUserByIdAsync(int id)
        {
            var user = _dbContext.Users
                .FromSqlRaw("EXECUTE dbo.GetUserById @Id", new SqlParameter("@Id", id))
                .AsEnumerable()
                .FirstOrDefault();

            return user;
        }

        public int AddUserAsync(UserModel userModel)
        {
            var name = new SqlParameter("@Name", userModel.Name);
            var email = new SqlParameter("@Email", userModel.Email);
            var phone = new SqlParameter("@Phone", userModel.Phone);
            var address = new SqlParameter("@Address", userModel.Address);
            var stateId = new SqlParameter("@StateId", userModel.StateId);
            var cityId = new SqlParameter("@CityId", userModel.CityId);

            var result = _dbContext.Database.ExecuteSqlRaw(
                "EXECUTE dbo.InsertUser @Name, @Email, @Phone, @Address, @StateId, @CityId",
                name, email, phone, address, stateId, cityId);

            return result;
        }

        public int UpdateUserAsync(int id, UserModel userModel)
        {
            var name = new SqlParameter("@Name", userModel.Name);
            var email = new SqlParameter("@Email", userModel.Email);
            var phone = new SqlParameter("@Phone", userModel.Phone);
            var address = new SqlParameter("@Address", userModel.Address);
            var stateId = new SqlParameter("@StateId", userModel.StateId);
            var cityId = new SqlParameter("@CityId", userModel.CityId);

            var result = _dbContext.Database.ExecuteSqlRaw(
                "EXECUTE dbo.UpdateUser @Id, @Name, @Email, @Phone, @Address, @StateId, @CityId",
                new SqlParameter("@Id", id), name, email, phone, address, stateId, cityId);

            return result;
        }

        public int DeleteUserAsync(int id)
        {
            var result = _dbContext.Database.ExecuteSqlRaw(
                "EXECUTE dbo.DeleteUser @Id", new SqlParameter("@Id", id));

            return result;
        }
    }
}
