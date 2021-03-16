using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.FileServices;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation
{
    public class FileService : IFileService
    {
        public Task<ServiceResultDetail<DTOMemberData>> Export(DTOMemberData memberDataModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResultDetail<DTOMemberData>> Import(DTOMemberData memberDataModel)
        {
            throw new NotImplementedException();
        }
    }
}
