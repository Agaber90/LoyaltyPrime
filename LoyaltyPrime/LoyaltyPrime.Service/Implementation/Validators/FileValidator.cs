using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Ground;
using LoyaltyPrime.Language.Resources;
using LoyaltyPrime.Service.Interfaces.FileServices;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.Validators
{
    public class FileValidator : IFileService
    {
       
        public async Task<ValidatorResult> Export(DTODownloadSearchCreateria searchModel)
        {
            if (searchModel.Points <= 0)
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.BalanceInCorrectFormat
                };
            }
            if ((int)AccountStatus.Active != Convert.ToInt32(searchModel.Status)
                || (int)AccountStatus.Inactive == Convert.ToInt32(searchModel.Status))
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.ValidateStatis
                };
            }

            return new ValidatorResult();
        }

        public Task<ServiceResultDetail<DTOMemberData>> Import(DTOImport importModel)
        {
            throw new NotImplementedException();
        }

        private async Task<ValidatorResult> IsFileContentTypeAllowed(string fileType)
        {
            if (fileType.ToLower() != ".json")
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.NotJsonFileError
                };
            }
            return new ValidatorResult();
        }
    }
}
