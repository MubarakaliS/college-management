using CollegeManagement.Context.Entity;
using CollegeManagement.Context.IService;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var res = await _userService.GetUserList();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(List<UserEntity> userModel)
        {
            if(userModel.Count < 0)
            {
                return BadRequest("Invalid params");
            }
            var res = await _userService.InsertUser(userModel);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest("Insert fail");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserList(long id)
        {
            if(id < 0)
            {
                return BadRequest($"Invalid UserId {id}");
            }
            var res = await _userService.GetUser(id);
            if (res == null) 
            {
                return NotFound(res);
            }
            return Ok(res);
        }
    }
}
