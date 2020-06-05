using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork.Interfaces;

namespace BLL.Services
{
    public class SensorService : ISensorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SensorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            if (mapper == null)
            {
                throw new ArgumentNullException(
                    nameof(mapper));
            }

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SensorDTO> GetSensorAsync(Guid id)
        {
            return _mapper.Map<Sensor, SensorDTO>(await GetById(id));
        }

        public async Task<SensorDTO> AddSensorAsync(SensorDTO region)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = _mapper.Map<SensorDTO, Sensor>(region);
            var result = await _unitOfWork.InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<Sensor, SensorDTO>(result);
        }

        public async Task RemoveSensor(Guid id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var sensor = await GetById(id);
            _unitOfWork.Remove(sensor);
            await _unitOfWork.CommitAsync();
        }

        private async Task<Sensor> GetById(Guid id)
        {
            var region = await _unitOfWork.GetByIdAsync<Sensor>(id);

            if (region == null)
            {
                throw new Exception("LocalPoint with following id was not found");
            }

            return region;
        }
    }
}