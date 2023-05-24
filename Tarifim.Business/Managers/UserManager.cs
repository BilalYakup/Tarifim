using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifim.Business.Dtos;
using Tarifim.Business.Services;
using Tarifim.Business.Types;
using Tarifim.Data.Entities;
using Tarifim.Data.Repositories;

namespace Tarifim.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtector _dataProtector;
        public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userRepository = userRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        public ServiceMessage addUser(UserDto userDto)
        {
            var mail = _userRepository.GetAll(x => x.Email.ToLower() == userDto.Email.ToLower());

            if (mail.Any())
            {
                return new ServiceMessage()
                {
                    IsSucceed = false,
                    Message = "Zaten böyle bir kayıt var"
                };
            }
            else
            {
                userDto.Password = _dataProtector.Protect(userDto.Password);

                var userEntity = new UserEntity()
                {
                    Name = userDto.Name,
                    SurName = userDto.SurName,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    UserType = Data.Enums.UserTypeEnum.user
                };
                _userRepository.Add(userEntity);
                return new ServiceMessage()
                {
                    IsSucceed = true,
                };
            }
        }

        public UserDto login(LoginDto loginDto)
        {
            var user = _userRepository.Get(x => x.Email.ToLower() == loginDto.Email.ToLower());

            if (user is null)
            {
                return null;
            }

             var rawPassword = _dataProtector.Unprotect(user.Password);
            
             if (loginDto.Password != rawPassword)
             {
                 return null;
             }
             else
             {

            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email,
                UserType = user.UserType,
            };

             }

        }

        public void updateUser(UserProfilDto userProfilDto)
        {
            var entity = _userRepository.GetById(userProfilDto.Id);
            entity.Name = userProfilDto.Name;
            entity.SurName = userProfilDto.SurName;
            entity.Email = userProfilDto.Email;
            _userRepository.Update(entity);
        }
    }
}
