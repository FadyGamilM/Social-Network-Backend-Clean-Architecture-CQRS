using Social.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Social.Application.UserProfileCQRS.Queries;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Social.Application.Helpers;
using Social.Application.Constants;
namespace Social.Application.UserProfileCQRS.QueryHandlers
{
   public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, GenericHandlersResponse<UserProfile>>
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

      async Task<GenericHandlersResponse<UserProfile>> IRequestHandler<GetProfileByIdQuery, GenericHandlersResponse<UserProfile>>.Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
      {
         var response = new GenericHandlersResponse<UserProfile>();
         try{
            var profile = await _context.Profiles.SingleOrDefaultAsync(p => p.UserProfileId == request.ProfileId);
            if (profile is null){
               var error = new Error{
                  Code = ErrorCode.NotFound,
                  Message = $"user profile with Id = {request.ProfileId} doesn't exist"
               };
               response.IsSuccess = false;
               response.Errors.Add(error);
            }
            response.IsSuccess = true;
            response.Payload = profile;
         }catch(Exception ex){
            var error = new Error{
               Code = ErrorCode.ServerError,
               Message = ex.Message
            };
            response.IsSuccess = false;
            response.Errors.Add(error);
         }
         return response;
      }
   }
}