using AutoMapper;
using MediatR;
using Social.Application.UserProfileCQRS.Commands;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Domain.ValueObjects.UserProfile;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Social.Application.Helpers;
using Social.Application.Constants;

namespace Social.Application.UserProfileCQRS.CommandHandlers
{
   public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, GenericHandlersResponse<UserProfile>>
   {
      private readonly AppDbContext _context;
      public CreateUserProfileCommandHandler(AppDbContext context)
      {
         _context = context;
      }

      public async Task<GenericHandlersResponse<UserProfile>> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
      {
         //* create an instance of general response object
         var response = new GenericHandlersResponse<UserProfile>();
         try
         {
            //* Use the factory method from the BasicInfo Entity in domain layer
            var basicInfo = BasicInfo.Create(
               request.FirstName,
               request.LastName,
               request.Email,
               request.Phone,
               request.CurrentCity,
               request.DateOfBirth
            );

            //* use the factory method from the user profile domain entity 
            var userProfile = UserProfile.Create(Guid.NewGuid().ToString(), basicInfo);

            //* save to the database
            await _context.Profiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
         
            //* manage the response instance to be returned
            response.Payload = userProfile;
            response.IsSuccess = true;
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
         //* return the result 
         return response;
      }
   }
}