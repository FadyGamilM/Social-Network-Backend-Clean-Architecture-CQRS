using Social.Application.UserProfileCQRS.Commands;
using MediatR;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Social.Domain.ValueObjects.UserProfile;
namespace Social.Application.UserProfileCQRS.CommandHandlers
{
   public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand>
   {
      private readonly AppDbContext _context;
      public UpdateUserProfileCommandHandler(AppDbContext context)
      {
         _context = context;
      }
      // we don't need to return anything so we will return the Task<Unit> .. 
      public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
      {
         var existingProfile = await _context.Profiles.Where(p => p.UserProfileId == request.profileId).SingleOrDefaultAsync();

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

         //* return 
         return new Unit();
      }
   }
}