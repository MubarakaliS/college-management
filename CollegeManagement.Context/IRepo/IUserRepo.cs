using CollegeManagement.Context.Entity;
using CollegeManagement.Context.Model;

namespace CollegeManagement.Context.IRepo
{
    public interface IUserRepo
    {
        Task<List<UserModel>> GetUserList();

        Task<UserModel?> GetUser(long userId);

        Task<bool> InsertUser(List<UserEntity> userModels);
    }
}
