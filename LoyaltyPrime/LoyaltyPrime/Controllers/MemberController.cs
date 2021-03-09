using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LoyaltyPrime.API.Controllers
{
    /// <summary>
    /// All Members Operations
    /// </summary>
    [Produces("application/json")]
    [Route("")]
    [ApiController]
    public class MemberController : BaseController
    {
        private Lazy<IMemberService> _memberService;

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="memberService"></param>
        public MemberController(Lazy<IMemberService> memberService)
        {
            _memberService = memberService;
        }
        private IMemberService MemberService => _memberService.Value;

        /// <summary>
        /// Create a new member
        /// </summary>
        /// <param name="memberModel"></param>
        /// <returns>A newly created member</returns>
        ///<response code="200">Returns the newly created member</response>
        ///<response code="400">If the member is null</response> 
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /member/createMember
        ///     {
        ///        "Name": "test",
        ///        "Addrss": "Cairo"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("member/createMember", Name = "CreateMamber")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTOMember))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMember(DTOMember memberModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var memberResult = await MemberService.AddMember(memberModel);
            if (!memberResult.IsValid) return GetErrorResult(memberResult);

            return Ok(memberResult);
        }
    }
}
