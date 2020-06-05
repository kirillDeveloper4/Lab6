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
    public class LocalPointService : ILocalPointService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocalPointService(IUnitOfWork unitOfWork, IMapper mapper)
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

        public async Task<LocalPointDTO> GetLocalPointAsync(Guid id)
        {
            return _mapper.Map<LocalPoint, LocalPointDTO>(await GetById(id));
        }

        public async Task<LocalPointDTO> AddLocalPointAsync(LocalPointDTO region)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = _mapper.Map<LocalPointDTO, LocalPoint>(region);
            var result = await _unitOfWork.InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<LocalPoint, LocalPointDTO>(result);
        }

        public async Task RemoveLocalPoint(Guid id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var region = await GetById(id);
            _unitOfWork.Remove(region);
            await _unitOfWork.CommitAsync();
        }

        private async Task<LocalPoint> GetById(Guid id)
        {
            var region = await _unitOfWork.GetByIdAsync<LocalPoint>(id);

            if (region == null)
            {
                throw new Exception("LocalPoint with following id was not found");
            }

            return region;
        }
    }
}