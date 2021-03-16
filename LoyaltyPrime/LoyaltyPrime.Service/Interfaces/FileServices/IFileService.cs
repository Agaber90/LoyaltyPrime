using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.FileServices
{
    public interface IFileService
    {
        Task<ServiceResultDetail<DTOMemberData>> Import(DTOMemberData memberDataModel);
        Task<ServiceResultDetail<DTOMemberData>> Export(DTOMemberData memberDataModel);


    }
}
