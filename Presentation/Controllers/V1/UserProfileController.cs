using MediatR;
using Microsoft.AspNetCore.Mvc;
using Social.Presentation.Contracts.ProfileContracts.Requests;
using AutoMapper;
using Social.Application.UserProfileCQRS.Commands;
using Social.Presentation.Contracts.ProfileContracts.Responses;
using Social.Application.UserProfileCQRS.Queries;

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
         //* define obejct instance of our query
         var query = new GetAllProfilesQuery();

         //* utlize the mediator to get the response
         var response = await _mediator.Send(query);

         //* map the response according to the API contract
         var profiles = _mapper.Map<IEnumerable<GetProfile>>(response);

         //* return the response
         return Ok(profiles);
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetProfileById([FromRoute] string id)
      {
         //* define the query object to send to the mediator
         var query = new GetProfileByIdQuery
         {
            ProfileId = Guid.Parse(id),
         };
         //* utilize the mediator to get the response
         var response = await _mediator.Send(query);
         //* map the response to the api contract
         var profile = _mapper.Map<GetProfile>(response);
         //* return the response to the end user
         return Ok(profile);
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

         return CreatedAtAction(nameof(GetProfileById), new { id = response.UserProfileId}, userprofile);
      }

      // PATCH req : update any field of an existing user profile
      [HttpPatch("{id}")]
      public async Task<IActionResult> UpdateProfile([FromRoute] string id, [FromBody] UpdateProfile profileDto)
      {
         //* get the command from the API.Contract
         var command = _mapper.Map<UpdateUserProfileCommand>(profileDto);

         //* the API.Contract has the basic info without the user id, but command handler expect from the command the profileId, so we need to add it here
         command.profileId = Guid.Parse(id);
         
         //* get the generic response from the mediator
         var response = await _mediator.Send(command);
         
         return NoContent();
      }

      // DELETE req : Delete an existing user profile
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteProfile([FromRoute] string id)
      {
         var command = new DeleteUserProfileCommand
         {
            ProfileId = Guid.Parse(id)
         };
         
         var response = await _mediator.Send(command);

         return NoContent();
      }

   }
}



























