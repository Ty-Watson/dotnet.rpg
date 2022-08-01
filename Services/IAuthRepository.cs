using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.rpg.Services
{
    public interface IAuthRepository
    {
        public  Task<bool> UserExists(string username);
        public Task<ServiceResponse<int>> Register(User user, string password);
    }
}