using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Entities;

namespace BLL.Profiles
{
    public class LocalPointProfile : Profile
    {
        public LocalPointProfile()
        {
            CreateMap<LocalPointDTO, LocalPoint>();
            CreateMap<LocalPoint, LocalPointDTO>();
        }
    }
}