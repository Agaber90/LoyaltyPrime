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
        Task<ValidatorResult> Import(DTOImport importModel);
        Task<ValidatorResult> Export(DTODownloadSearchCreateria searchModel);


    }
}
