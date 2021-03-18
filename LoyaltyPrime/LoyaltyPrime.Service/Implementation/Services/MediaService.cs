using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.Repositories;
using LoyaltyPrime.Service.Interfaces.Services;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.Services
{
    public class MediaService : IMediaService
    {
        private readonly Lazy<IFileServiceValidator> _fileServiceValidator;
        private readonly Lazy<IAccountRepository> _accountRepository;
        public MediaService(Lazy<IFileServiceValidator> fileServiceValidator,
            Lazy<IAccountRepository> accountRepository)
        {
            _fileServiceValidator = fileServiceValidator;
            _accountRepository = accountRepository;

        }

        private IFileServiceValidator FileServiceValidator => _fileServiceValidator.Value;
        private IAccountRepository AccountRepository => _accountRepository.Value;

        public async Task<ServiceResultList<DTOMemberData>> Export
            (DTODownloadSearchCreateria searchModel)
        {
            var exportValidator = await FileServiceValidator.ExportItemValidator(searchModel);
            if (!exportValidator.IsValid)
            {
                return new ServiceResultList<DTOMemberData>()
                {
                    IsValid = false,
                    Messages = new List<string>() { exportValidator.Message }
                };
            }

            var result = await AccountRepository.DownloadMember(searchModel);
            if (result.Any())
            {
                return new ServiceResultList<DTOMemberData>
                {
                    Model=result.ToList()
                };
            }
            return new ServiceResultList<DTOMemberData>();
        }

        public Task<ServiceResultList<DTOMemberData>> Import(DTOImport importModel)
        {
            
        }
    }
}
