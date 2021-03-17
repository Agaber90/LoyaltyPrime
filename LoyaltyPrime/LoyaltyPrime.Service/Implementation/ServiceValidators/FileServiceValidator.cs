using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.FileServices;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.ServiceValidators
{
    public class FileServiceValidator : IFileServiceValidator
    {
        private readonly Lazy<IFileService> _fileServiceValidator;
        public FileServiceValidator(Lazy<IFileService> fileServiceValidator)
        {
            _fileServiceValidator = fileServiceValidator;
        }

        private IFileService FileService => _fileServiceValidator.Value;

        public async Task<ValidatorResult> ExportItemValidator(DTODownloadSearchCreateria searchModel)
        {
            var fileServiceValidation = new List<Task<ValidatorResult>>()
            {
                FileService.Export(searchModel)
            };

            await Task.WhenAll(fileServiceValidation);
            var taskResult = fileServiceValidation.Select(a => a.Result).FirstOrDefault(a => !a.IsValid);
            if (taskResult != null) return taskResult;
            return new ValidatorResult();
        }
    }
}
