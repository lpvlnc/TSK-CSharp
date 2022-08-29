using AutoMapper;
using TSK.DTO;
using TSK.Model;

namespace TSK.API.Helpers
{
    public class TSKProfile : Profile
    {
        public TSKProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
