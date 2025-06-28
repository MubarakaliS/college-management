using CollegeManagement.Context.IRepo;
using CollegeManagement.Context.IService;
using CollegeManagement.Repo.Repository;
using CollegeManagement.Service.Service;

namespace CollegeMangementAPI
{
    public class DependencyInjection
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();
        }
    }
}
