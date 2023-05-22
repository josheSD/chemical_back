using chemical.back.Common;
using chemical.back.DTO;

namespace chemical.back.Interface.UseCases
{
    public interface IUserApplication
    {

        Task<Response<bool>> AddSync(UserCreateDto userCreateDto);

        Task<Response<bool>> UpdateSync(UserUpdateDto userUpdateDto);

        Task<Response<bool>> RemoveSync(UserRemoveDto userRemoveDto);

        Task<Response<List<UserListarDto>>> GetAllSync();
    }
}
