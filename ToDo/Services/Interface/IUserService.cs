using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Entities;
using ToDo.Models.Dtos;

namespace ToDo.Services.Interface
{
    public interface IUserService
    {
        int RegisterUser(RegisterUserDto dto);

        string GenerateLoginToken(LoginDto dto);

        List<User> GetUsers();
    }
}