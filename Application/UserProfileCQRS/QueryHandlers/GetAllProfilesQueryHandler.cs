using Social.Application.UserProfileCQRS.Queries;
using Social.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Social.Application.UserProfileCQRS.QueryHandlers
{
   public class GetAllProfilesQUeryHandler : IRequestHandler<GetAllProfilesQuery, IEnumerable<UserProfile>>
   {
         //* inject the db context from infrastructure layer
         private readonly AppDbContext _context;
         public GetAllProfilesQUeryHandler(AppDbContext context)
         {
            _context = context;
         }
         public async Task<IEnumerable<UserProfile>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
         {
            //* get all profiles from the db context
            var profiles = await _context.Profiles.ToListAsync();
            return profiles;
         }
   }
}