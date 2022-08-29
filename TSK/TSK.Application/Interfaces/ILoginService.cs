using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSK.Model;
using TSK.Model.Login;

namespace TSK.Application.Interfaces
{
    public interface ILoginService
    {
        public Token Login(Login login, string key, string validIssuer, string validAudience);
        public string GenerateHash(string source);
        public bool CompareHash(string firsthash, string secondHash);
    }
}
