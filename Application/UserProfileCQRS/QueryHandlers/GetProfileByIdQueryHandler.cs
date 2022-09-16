using Social.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Social.Application.UserProfileCQRS.Queries;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Social.Application.UserProfileCQRS.QueryHandlers
{
   public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, UserProfile>
   {
      private readonly AppDbContext _context;
      public GetProfileByIdQueryHandler(AppDbContext context)
      {
         _context = context;
      }
      public async Task<UserProfile> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
      {
         //* get the profile 
         var profile = await _context.Profiles
                                                   .SingleOrDefaultAsync( profile => profile.UserProfileId == request.ProfileId);
         return profile;
      }
   }
}