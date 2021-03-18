using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Model;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Services
{
    public interface IMediaService
    {
        Task<ServiceResultList<DTOMemberData>> Export(DTODownloadSearchCreateria searchModel);

        Task<ServiceResultList<DTOMemberData>> Import(DTOImport importModel);

    }
}
