using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Application.Helpers;
using MediatR;
namespace Social.Application.UserProfileCQRS.Queries
{
   public class GetProfileByIdQuery : IRequest<GenericHandlersResponse<UserProfile>>
   {
      //* in the query handler we will need the id to fetch this user, so we define this property in the query
      public Guid ProfileId{get; set; }
   }
}