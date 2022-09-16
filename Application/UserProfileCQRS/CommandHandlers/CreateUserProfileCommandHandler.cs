using AutoMapper;
using MediatR;
using Social.Application.UserProfileCQRS.Commands;
using Social.Domain.Aggregates.UserProfileAggregate;
using Social.Domain.ValueObjects.UserProfile;
using Social.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Social.Application.UserProfileCQRS.CommandHandlers
{
   public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
   {
      private readonly AppDbContext _context;
      private readonly IMapper _mapper;
      public CreateUserProfileCommandHandler(AppDbContext context, IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }
      async Task<UserProfile> IRequestHandler<CreateUserProfileCommand, UserProfile>.Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
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

         //* 
         await _context.Profiles.AddAsync(userProfile);
         await _context.SaveChangesAsync();
         return userProfile;
      }
   }
}