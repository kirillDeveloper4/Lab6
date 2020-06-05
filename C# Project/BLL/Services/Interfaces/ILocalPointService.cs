using System;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface ILocalPointService
    {
        Task<LocalPointDTO> GetLocalPointAsync(Guid id);
        Task<LocalPointDTO> AddLocalPointAsync(LocalPointDTO region);
        Task RemoveLocalPoint(Guid id);
    }
}