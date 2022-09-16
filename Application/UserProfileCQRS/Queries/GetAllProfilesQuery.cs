using MediatR;
using Social.Domain.Aggregates.UserProfileAggregate;

namespace Social.Application.UserProfileCQRS.Queries
{
   public class GetAllProfilesQuery : IRequest<IEnumerable<UserProfile>>
   {

   }
}