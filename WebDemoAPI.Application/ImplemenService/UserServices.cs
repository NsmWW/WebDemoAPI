using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebDemoAPI.Application.InterfaceService;
using WebDemoAPI.Application.Payload.BaseRespone;
using WebDemoAPI.Application.Payload.Mapper;
using WebDemoAPI.Application.Payload.Respone;
using WebDemoAPI.Application.Payload.Resquest.UserResquest;
using WebDemoAPI.Domain;
using WebDemoAPI.Domain.InterfaceREpository;
using WebDemoAPI.Domain.Validation;

namespace WebDemoAPI.Application.ImplemenService
{
    public class UserServices : IAservice
    {
        private readonly IUserReposytory _iuserReposytory;
        private readonly IBaseRepository<User> _userRepository;
        private readonly UserDataConverter _userDataConverter;

        public UserServices() { }
        public UserServices(IUserReposytory iuserReposytory, IBaseRepository<User> userRepository, UserDataConverter userDataConverter)
        {
            _iuserReposytory = iuserReposytory;
            _userRepository = userRepository;
            _userDataConverter = userDataConverter;

        }

        public async Task<ResponeOject<DataUserRespone>> Register(Request_Register request_Register)
        {
            try
            {
                if (!Validateinput.IsValiEmail(request_Register.Email))
                {
                    new ResponeOject<DataUserRespone>
                    {
                        Data = null,
                        Message = "Email khong hop le",
                        Status = StatusCodes.Status204NoContent,
                    };
                }
                if (await _iuserReposytory.GetUserByEmail(request_Register.Email) != null)
                {
                    new ResponeOject<DataUserRespone>
                    {
                        Data = null,
                        Message = "Email da ton tai",
                        Status = StatusCodes.Status204NoContent,
                    };
                }
                if (await _iuserReposytory.GetUserByUSername(request_Register.Username) != null)
                {
                    new ResponeOject<DataUserRespone>
                    {
                        Data = null,
                        Message = "Username da ton tai",
                        Status = StatusCodes.Status204NoContent,
                    };
                }
                var user = new User()
                {
                    Avatar = null,
                    Username = request_Register.Username,
                    CreateTime = DateTime.UtcNow,
                    Email = request_Register.Email,
                    UpdateTime = null,
                    Password = BCrypt.Net.BCrypt.HashPassword(request_Register.Password),
                    Fullname = request_Register.Fullname,
                    DateOfBirt = null,
                    IsActive = true,
                };
                user = await _userRepository.CreateAsync(user);
                await _iuserReposytory.AllrollofUserAysnc(user, new List<string> { "Student" });
                return new ResponeOject<DataUserRespone>
                {
                    Message = " khoi tao user thanh cong",
                    Status = StatusCodes.Status200OK,
                    Data = _userDataConverter.Entity(user),
                };
            }
            catch
            {
                return new ResponeOject<DataUserRespone>
                {
                    Data = null,
                    Message = "khoi tao user that bai",
                    Status = StatusCodes.Status204NoContent,
                };
            }

        }
    }
}
