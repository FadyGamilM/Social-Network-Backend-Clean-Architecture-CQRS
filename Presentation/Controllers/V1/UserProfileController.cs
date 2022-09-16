using MediatR;
using Microsoft.AspNetCore.Mvc;
using Social.Presentation.Contracts.ProfileContracts.Requests;
using AutoMapper;
using Social.Application.UserProfileCQRS.Commands;
using Social.Presentation.Contracts.ProfileContracts.Responses;

namespace Social.Presentation.Controllers.V1
{
   [ApiController]
   [Route("api/v{version:apiVersion}/profile")]
   public class UserProfileController : ControllerBase
   {
      //! Inject the mediator pattern to send commands
      private readonly IMediator _mediator;
      private readonly IMapper _mapper;
      public UserProfileController(IMediator mediator, IMapper mapper)
      {  
         _mediator = mediator;
         _mapper = mapper;
      }

      [HttpGet("")]
      public async Task<IActionResult> GetAllProfiles()
      {
         return Ok();
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetProfileById([FromRoute] string profileId)
      {
         return Ok();
      }

      [HttpPost("")]
      public async Task<IActionResult> CreateUserProfile([FromBody] CreateProfile profileContract)  
      {
         //* create a user profile command from the recieved CreateProfile contract
         //* so this step is the transaltion between what handlers need and the data from our users and vice versa
         var command = _mapper.Map<CreateUserProfileCommand>(profileContract);

         //* Send this command now to the mediator
         //* the mediator will be responsible for selecting which handler to choose for this command
         var response  = await _mediator.Send(command);

         //* Map the response to the contract 
         var userprofile = _mapper.Map<GetProfile>(response);

         return CreatedAtAction(nameof(GetProfileById), new Object{ id = response.UserProfileId}, userprofile);
      }

   }
}