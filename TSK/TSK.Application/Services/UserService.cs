using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSK.Application.Interfaces;
using TSK.Data;
using TSK.DTO;
using TSK.ExceptionHandler;
using TSK.Model;
using TSK.Security;

namespace TSK.Application.Services
{
    public class UserService : IUserService
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            this._dataContext = context;
            this._mapper = mapper;
        }

        public List<UserDTO> Get()
        {
            var users =_dataContext.User.ToList();
            return _mapper.Map<List<UserDTO>>(users) ?? throw new TskException($"No data of type {typeof(User)} has been found.", 412);
        }

        public UserDTO GetByID(int id)
        {
            var user = _dataContext.User.Where(x => x.ID == id).SingleOrDefault();
            return _mapper.Map<UserDTO>(user) ?? throw new TskException($"No data of type {typeof(User)} with ID {id} has been found.", 412);
        }

        private User GetFullByID(int id)
        {
            var user = _dataContext.User.Where(x => x.ID == id).SingleOrDefault();
            return user ?? throw new TskException($"No data of type {typeof(User)} with ID {id} has been found.", 412);
        }

        public User GetByCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new TskException("Username and Password must be informed.", string.Empty, 412);
            var encryptedPassword = Cryptography.GenerateHash(password);
            return _dataContext.User.Where(x => x.Username == username && x.Password == encryptedPassword).SingleOrDefault() ?? throw new TskException("Invalid credentials.", 412);
        }

        public void Insert(User user)
        {
            user.ID = 0;
            _dataContext.User.Add(user);
            _dataContext.SaveChanges();
        }

        public void Update(int id, UserDTO user)
        {
            var currentUser = GetFullByID(id);
            var newUser = PatchDtoValuesToModel(user, currentUser);
            _dataContext.Entry(currentUser).CurrentValues.SetValues(newUser);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetFullByID(id);

            if (user == null)
                throw new TskException($"No data of type {typeof(User)} with ID {id} has been found.", 412);

            _dataContext.User.Remove(user);
            _dataContext.SaveChanges();
        }

        private static User PatchDtoValuesToModel(UserDTO dto, User user)
        {
            user.Username = dto.Username;
            user.Name = dto.Name;
            user.Lastname = dto.Lastname;
            user.Email = dto.Email;
            user.EmailConfirmed = dto.EmailConfirmed;
            return user;
        }
    }
}
