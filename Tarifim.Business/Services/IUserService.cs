using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarifim.Business.Dtos;
using Tarifim.Business.Types;

namespace Tarifim.Business.Services
{
    public interface IUserService
    {
        ServiceMessage addUser(UserDto userDto);

        UserDto login(LoginDto loginDto);

        void updateUser(UserProfilDto userProfilDto);
    }
}
