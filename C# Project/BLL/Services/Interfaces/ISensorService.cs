using System;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ISensorService
    {
        Task<SensorDTO> GetSensorAsync(Guid id);
        Task<SensorDTO> AddSensorAsync(SensorDTO region);
        Task RemoveSensor(Guid id);
    }
}