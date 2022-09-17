using System.Linq;
using Social.Application.UserProfileCQRS.Commands;
using MediatR;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Social.Domain.ValueObjects.UserProfile;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Application.Helpers;
using Social.Application.Constants;
namespace Social.Application.UserProfileCQRS.CommandHandlers
{
   public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, GenericHandlersResponse<UserProfile>>
   {
      private readonly AppDbContext _context;
      public UpdateUserProfileCommandHandler(AppDbContext context)
      {
         _context = context;
      }
      // we don't need to return anything so we will return the Task<Unit> .. 
      public async Task<GenericHandlersResponse<UserProfile>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
      {
         //* Create an instance of the generic response 
         var response = new GenericHandlersResponse<UserProfile>();

         try
         {
            //* utlize the Db Context to get the user profile from the database
            var existingProfile = await _context.Profiles.Where(p => p.UserProfileId == request.profileId).SingleOrDefaultAsync();

            //* Application Layer Validation <<
            if (existingProfile is null)
            {
               response.IsSuccess = false;
               response.Errors.Append(
                  new Error{
                     Code = ErrorCode.NotFound,
                     Message = $"There is no user profile with id = {request.profileId}"
                  }
               );
               return response;
            }

            //* create instance of the basic info object
            var basicInfo = BasicInfo.Create(
               request.FirstName == null ? existingProfile.BasicInfo.FirstName : request.FirstName,
               request.LastName== null ? existingProfile.BasicInfo.LastName : request.LastName,
               request.CurrentCity == null ? existingProfile.BasicInfo.CurrentCity : request.CurrentCity,
               request.Phone == null ? existingProfile.BasicInfo.Phone : request.Phone,
               request.Email == null ? existingProfile.BasicInfo.Email : request.Email,
               request.DateOfBirth == null ? existingProfile.BasicInfo.DateOfBirth : request.DateOfBirth
            );

            //* update the basic info using the domain-entity behaviour method
            existingProfile.UpdateProfile(basicInfo);

            //* update the user profile through the context
            _context.Profiles.Update(existingProfile);
            await _context.SaveChangesAsync();
            
            //* handle the response properties 
            response.IsSuccess = true;
            response.Payload = existingProfile;
         }
         catch(Exception ex)
         {
            response.IsSuccess = false;
            response.Errors.Append(
               new Error{
                  Code = ErrorCode.ServerError,
                  Message = ex.Message
               }
            );
         }

         //* return the generic response
         return response;
      }
   }
}