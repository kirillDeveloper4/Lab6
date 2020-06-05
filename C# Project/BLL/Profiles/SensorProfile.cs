using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Profiles
{
    class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<Sensor, SensorDTO>();
            CreateMap<SensorDTO, Sensor>();
        }
    }
}
