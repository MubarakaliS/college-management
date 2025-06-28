using CollegeManagement.Context.Entity;
using CollegeManagement.Context.IRepo;
using CollegeManagement.Context.Model;
using CollegeManagement.Repo.SqlConstant;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace CollegeManagement.Repo.Repository
{
    public class UserRepo : IUserRepo
    {
        private IConfiguration _configuration;
        public UserRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<UserModel>> GetUserList()
        {
            var connectionString = _configuration.GetConnectionString("sqlConnection");
            using var con = new MySqlConnection(connectionString);
            return (await con.QueryAsync<UserModel>(UserSqlConstant.SELECT_USER_LIST)).AsList();
        }

        public async Task<UserModel?> GetUser(long userId)
        {
            var connectionString = _configuration.GetConnectionString("sqlConnection");
            using var con = new MySqlConnection(connectionString);
            return (await con.QueryFirstOrDefaultAsync<UserModel?>(UserSqlConstant.SELECT_USER, new { Id = userId }));
        }
        public async Task<bool> InsertUser(List<UserEntity> userModels)
        {
            var connectionString = _configuration.GetConnectionString("sqlConnection");
            using var con = new MySqlConnection(connectionString);
            await con.OpenAsync();

            using var transaction = await con.BeginTransactionAsync();
            try
            {
                foreach (var user in userModels)
                {
                    await con.ExecuteAsync(UserSqlConstant.INSERT_USER, user, transaction);
                }

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

    }
}
