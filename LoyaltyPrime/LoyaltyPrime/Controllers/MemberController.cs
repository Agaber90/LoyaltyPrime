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
    [Route("")]
    [ApiController]
    public class MemberController : BaseController
    {
        private Lazy<IMemberService> _memberService;
        public MemberController(Lazy<IMemberService> memberService)
        {
            _memberService = memberService;
        }
        private IMemberService MemberService => _memberService.Value;

        [HttpPost]
        [Route("member/createMember", Name = "CreateMamber")]
        public async Task<IActionResult> CreateMember(DTOMember memberModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var memberResult = await MemberService.AddMember(memberModel);
            if (!memberResult.IsValid) return GetErrorResult(memberResult);

            return Ok();
        }
    }
}
