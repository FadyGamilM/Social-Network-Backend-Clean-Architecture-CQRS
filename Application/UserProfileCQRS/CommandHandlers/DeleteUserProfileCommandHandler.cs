using MediatR;
using Microsoft.EntityFrameworkCore;
using Social.Application.UserProfileCQRS.Commands;
using Social.Infrastructure.Data;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Application.Helpers;
using Social.Application.Constants;

namespace Social.Application.UserProfileCQRS.CommandHandlers
{
   public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, GenericHandlersResponse<UserProfile>>
   {
      private readonly AppDbContext _context;
      public DeleteUserProfileCommandHandler(AppDbContext context)
      {
         _context = context;
      }
      public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
      {
         var profile = await _context.Profiles.Where(p => p.UserProfileId == request.ProfileId).SingleOrDefaultAsync();
         _context.Profiles.Remove(profile);
         await _context.SaveChangesAsync();
         return new Unit();
      }

      async Task<GenericHandlersResponse<UserProfile>> IRequestHandler<DeleteUserProfileCommand, GenericHandlersResponse<UserProfile>>.Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
      {
         // create instnace of the response we want to return to the controller
         var response = new GenericHandlersResponse<UserProfile>();
         try
         {
            // get the profile we need to delete
            var profile = await _context.Profiles.Where(p => p.UserProfileId == request.ProfileId).SingleOrDefaultAsync();
            
            // check if this profile exists
            if (profile is null)
            {
               response.IsSuccess = false;
               var error = new Error
               {
                  Code = ErrorCode.NotFound,
                  Message = $"User profile with id = {request.ProfileId} doesn't exists"
               };
               response.Errors.Add(error);
               return response;
            }

            // delete the profile using the db context and save the changes
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
         }         
         catch(Exception ex)
         {
            response.IsSuccess = false;
            var error = new Error
            {
               Code = ErrorCode.ServerError,
               Message = ex.Message
            };
            response.Errors.Add(error);
         }
         // return the response
         return response;
      }
   }
}