using MediatR;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Application.Helpers;
namespace Social.Application.UserProfileCQRS.Queries
{
   public class GetAllProfilesQuery : IRequest<GenericHandlersResponse<IEnumerable<UserProfile>>>
   {

   }
}