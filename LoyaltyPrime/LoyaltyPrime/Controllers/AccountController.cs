using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Constractor
        /// </summary>
        public AccountController(Lazy<IAccountService> accountService)
        {
            _accountService = accountService;
        }
        private IAccountService AccountService => _accountService.Value;

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
    }
}
