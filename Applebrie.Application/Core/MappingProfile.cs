using Applebrie.Application.Users;
using Applebrie.Domain;
using AutoMapper;

namespace Applebrie.Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
