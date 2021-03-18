using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace LoyaltyPrime.API.Controllers
{
    /// <summary>
    /// All Account Operation
    /// </summary>
    [Produces("application/json")]
    [Route("")]
    [ApiController]
    public class AccountController : BaseController
    {
        /// <summary>
        /// Account Services
        /// </summary>
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<IMediaService> _mediaService;
        /// <summary>
        /// Constractor
        /// </summary>
        public AccountController(Lazy<IAccountService> accountService
                , Lazy<IMediaService> mediaService)
        {
            _accountService = accountService;
            _mediaService = mediaService;
        }
        private IAccountService AccountService => _accountService.Value;
        private IMediaService MediaService => _mediaService.Value;

        /// <summary>
        /// Create a new account for existing member
        /// </summary>
        /// <param name="accountMember"></param>
        /// <returns>A newly created Account</returns>
        ///<response code="200">Returns the newly created member</response>
        ///<response code="400">If the member is null</response> 
        [HttpPost]
        [Route("account/createaccount", Name = "CreateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTOAccount))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAccount(DTOAccount accountMember)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var accountResult = await AccountService.AddAccount(accountMember);
            if (!accountResult.IsValid) return GetErrorResult(accountResult);
            return Ok(accountResult);
        }

        /// <summary>
        /// Member can collect points if account is valid
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns>Sub Total points</returns>
        ///<response code="200">Returns the newly created member</response>
        ///<response code="400">If the member is null</response> 
        [HttpGet]
        [Route("account/collectpoints/{memberID}", Name = "CollectPoints")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CollectPoints(long memberID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var accountResult = await AccountService.CollectPointsByActiveAccount(memberID);
            if (!accountResult.IsValid) return GetErrorResult(accountResult);
            return Ok(accountResult);
        }

        /// <summary>
        /// Redeem Points
        /// </summary>
        /// <param name="dTORedeemPoint"></param>
        /// <returns>Redeemed Message</returns>
        ///<response code="200">Returns the newly created member</response>
        ///<response code="400">If the member is null</response> 
        [HttpPost]
        [Route("account/RedeemPoints", Name = "RedeemPoints")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTORedeemPoint))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RedeemPoints(DTORedeemPoint dTORedeemPoint)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var reedemPoints = await AccountService.RedeemPoints(dTORedeemPoint);
            if (!reedemPoints.IsValid) return GetErrorResult(reedemPoints);
            return Ok(reedemPoints);
        }

        //[HttpPost]
        //public async Task<IActionResult> ImportMember()
        //{

        //}

        /// <summary>
        /// Export Member
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("account/exportMember/", Name = "ExportMember")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTODownloadSearchCreateria))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExportMember(DTODownloadSearchCreateria searchModel)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var exportLstResult = await MediaService.ExportMember(searchModel);
            if (exportLstResult.IsValid) GetErrorResult(exportLstResult);

            var lstData = exportLstResult.Model;
            formatter.Serialize(memStream, lstData);

            byte[] listBytes = memStream.ToArray();


            return File(listBytes, "application/octet-stream", "member.jsom");
        }
    }
}
