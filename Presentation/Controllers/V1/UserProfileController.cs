using Microsoft.AspNetCore.Mvc;

namespace Social.Presentation.Controllers.V1
{
   [ApiController]
   [Route("api/v{version:apiVersion}/profile")]
   public class UserProfileController : ControllerBase
   {
      public UserProfileController()
      {  }

      [HttpGet("")]
      public async Task<IActionResult> GetAllProfiles()
      {
         return Ok();
      }

      [HttpGet("{id:Guid}")]
      public async Task<IActionResult> GetProfileByUserId([FromRoute] Guid profileId)
      {
         return Ok();
      }      
   }
}