using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSK.Application.Interfaces;
using TSK.ExceptionHandler;
using TSK.Model;
using TSK.Model.Login;
using TSK.Security;

namespace TSK.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;

        public LoginService(IUserService userService)
        {
            _userService = userService;
        }

        public Token Login(Login login, string key, string validIssuer, string validAudience)
        {
            var user = _userService.GetByCredentials(login.Username, login.Password);
            return new TokenProvider().GenerateToken(user.ID, user.Username, key, validIssuer, validAudience);
        }

        public string GenerateHash(string source)
        {
            return Cryptography.GenerateHash(source);
        }

        public bool CompareHash(string firsthash, string secondHash)
        {
            return Cryptography.CompareHash(firsthash, secondHash);
        }
    }
}
