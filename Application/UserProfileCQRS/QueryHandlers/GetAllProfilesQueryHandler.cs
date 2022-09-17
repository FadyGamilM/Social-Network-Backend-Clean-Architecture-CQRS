using Social.Application.UserProfileCQRS.Queries;
using Social.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Social.Application.Constants;
using Social.Application.Helpers;

namespace Social.Application.UserProfileCQRS.QueryHandlers
{
   public class GetAllProfilesQUeryHandler : IRequestHandler<GetAllProfilesQuery, GenericHandlersResponse<IEnumerable<UserProfile>>>
   {
         //* inject the db context from infrastructure layer
         private readonly AppDbContext _context;
         public GetAllProfilesQUeryHandler(AppDbContext context)
         {
            _context = context;
         }
         public async Task<GenericHandlersResponse<IEnumerable<UserProfile>>> Handle(GetAllProfilesQuery request, CancellationToken cancellationToken)
         {
            var response = new GenericHandlersResponse<IEnumerable<UserProfile>>();
            try
            {
               //* get all profiles from the db context
               var profiles = await _context.Profiles.ToListAsync();
               response.IsSuccess = true;
               response.Payload = profiles;
            }
            catch(Exception ex)
            {
               response.IsSuccess = false;
               var error = new Error{
                  Code = ErrorCode.ServerError,
                  Message = ex.Message
               };
               response.Errors.Add(error);
            }
            return response;
         }
   }
}