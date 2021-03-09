using LoyaltyPrime.Ground;
using LoyaltyPrime.Service.Model;
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
    public class BaseController : ControllerBase
    {
        protected IActionResult GetErrorResult<T>(IServiceResult<T> result) where T : class
        {
            if (result == null)
            {
                return StatusCode(500);
            }
            if (result.Status == ValidationStatus.NotFound)
            {
                return StatusCode(404);
            }
            if (result.Status == ValidationStatus.Accepted)
            {
                // request accepted but still in processing https://restfulapi.net/http-status-202-accepted/
                return StatusCode(202, new { messages = result.Messages });
            }
            foreach (string message in result.Messages)
            {
                ModelState.AddModelError("errors", message);
            }
            if (ModelState.IsValid)
            {
                // No ModelState errors are available to send, so just return an empty BadRequest.
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
    }
}
