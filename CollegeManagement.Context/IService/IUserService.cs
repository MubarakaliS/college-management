using CollegeManagement.Context.Entity;
using CollegeManagement.Context.Model;

namespace CollegeManagement.Context.IService
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUserList();

        Task<UserModel?> GetUser(long userId);

        Task<bool> InsertUser(List<UserEntity> userModels);
    }
}
