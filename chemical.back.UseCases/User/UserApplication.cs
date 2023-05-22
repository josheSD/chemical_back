using AutoMapper;
using chemical.back.Common;
using chemical.back.Domain.Entities;
using chemical.back.DTO;
using chemical.back.Interface.Persistence;
using chemical.back.Interface.UseCases;
using chemical.back.Validator;
using FluentValidation.Results;
using Hls.Hotel.Transversal.Common;

namespace chemical.back.UseCases
{
    public class UserApplication : IUserApplication
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserCreateDtoValidator _userCreateDtoValidator;
        private readonly UserUpdateDtoValidator _userUpdateDtoValidator;
        private readonly UserRemoveDtoValidator _userRemoveDtoValidator;

        public UserApplication(
            IMapper mapper,
            IUserRepository userRepository,
            UserCreateDtoValidator userCreateDtoValidator, 
            UserUpdateDtoValidator userUpdateDtoValidator, 
            UserRemoveDtoValidator userRemoveDtoValidator
        )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userCreateDtoValidator = userCreateDtoValidator;
            _userUpdateDtoValidator = userUpdateDtoValidator;
            _userRemoveDtoValidator = userRemoveDtoValidator;
        }

        public async Task<Response<List<UserListarDto>>> GetAllSync()
        {
            Response<List<UserListarDto>> response = new Response<List<UserListarDto>>();

            try
            {
                IEnumerable<User> users = await _userRepository.GetAllAsync();

                List<UserListarDto> usersDto = _mapper.Map<List<UserListarDto>>(users);

                response.Data = usersDto;
                response.Code = ErrorCode.CHE_0200;
                response.IsSuccess = true;
                return response;
            }
            catch( Exception ex)
            {
                response.Code = ErrorCode.CHE_9999;
                response.IsSuccess = false;
                return response;
            }
        }

        public async Task<Response<bool>> AddSync(UserCreateDto userCreateDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                ValidationResult validation = await _userCreateDtoValidator.ValidateAsync(userCreateDto, default);
                if (!validation.IsValid)
                {
                    response.Code = ErrorCode.CHE_9999;
                    response.IsSuccess = false;
                    return response;
                }

                User user = _mapper.Map<User>(userCreateDto);
                user.UsePassword = EncryptUility.Encrypt(user.UsePassword);
                var execute = await _userRepository.AddSync(user);

                if (!execute)
                {
                    response.Code = ErrorCode.CHE_9999;
                    response.IsSuccess = false;
                    return response;
                }

                response.Code = ErrorCode.CHE_0200;
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Code = ErrorCode.CHE_9999;
                response.IsSuccess = false;
                return response;
            }
        }

        public async Task<Response<bool>> UpdateSync(UserUpdateDto userUpdateDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                ValidationResult validation = await _userUpdateDtoValidator.ValidateAsync(userUpdateDto, default);
                if (!validation.IsValid)
                {
                    response.Code = ErrorCode.CHE_9999;
                    response.IsSuccess = false;
                    return response;
                }

                User user = _mapper.Map<User>(userUpdateDto);
                user.UsePassword = EncryptUility.Encrypt(user.UsePassword);
                var execute = await _userRepository.UpdateAsync(user);

                if (!execute)
                {
                    response.Code = ErrorCode.CHE_9999;
                    response.IsSuccess = false;
                    return response;
                }

                response.Code = ErrorCode.CHE_0200;
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Code = ErrorCode.CHE_9999;
                response.IsSuccess = false;
                return response;
            }
        }

        public async Task<Response<bool>> RemoveSync(UserRemoveDto userRemoveDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                ValidationResult validation = await _userRemoveDtoValidator.ValidateAsync(userRemoveDto, default);
                if (!validation.IsValid)
                {
                    response.Code = ErrorCode.CHE_9999;
                    response.IsSuccess = false;
                    return response;
                }

                User user = _mapper.Map<User>(userRemoveDto);
                var execute = await _userRepository.RemoveAsync(user);

                if (!execute)
                {
                    response.Code = ErrorCode.CHE_9999;
                    response.IsSuccess = false;
                    return response;
                }

                response.Code = ErrorCode.CHE_0200;
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Code = ErrorCode.CHE_9999;
                response.IsSuccess = false;
                return response;
            }
        }
    }
}
