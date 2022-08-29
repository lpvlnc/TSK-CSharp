using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSK.DTO;
using TSK.Model;

namespace TSK.Application.Interfaces
{
    public interface IUserService
    {
        public List<UserDTO> Get();

        public UserDTO GetByID(int id);

        public User GetByCredentials(string username, string password);

        public void Insert(User user);

        public void Update(int id, UserDTO user);

        public void Delete(int id);
    }
}
