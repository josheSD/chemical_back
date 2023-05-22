using chemical.back.Common;
using chemical.back.DTO;
using chemical.back.Interface.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace chemical.back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserCreateDto userCreateDto)
        {
            Response<bool> response = await _userApplication.AddSync(userCreateDto);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userDto)
        {
            Response<bool> response = await _userApplication.UpdateSync(userDto);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("Remove")]
        public async Task<IActionResult> Delete([FromBody] UserRemoveDto userRemoveDto)
        {
            Response<bool> response = await _userApplication.RemoveSync(userRemoveDto);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Response<List<UserListarDto>> response = await _userApplication.GetAllSync();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
