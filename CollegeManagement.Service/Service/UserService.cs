using CollegeManagement.Context.Entity;
using CollegeManagement.Context.IRepo;
using CollegeManagement.Context.IService;
using CollegeManagement.Context.Model;

namespace CollegeManagement.Service.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<List<UserModel>> GetUserList()
        {
            return await _userRepo.GetUserList();
        }

        public async Task<UserModel?> GetUser(long userId)
        {
            return await _userRepo.GetUser(userId);
        }

        public async Task<bool> InsertUser(List<UserEntity> userModels)
        {
            return await _userRepo.InsertUser(userModels);
        }
    }
}
