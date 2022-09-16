using MediatR;
using Microsoft.EntityFrameworkCore;
using Social.Application.UserProfileCQRS.Commands;
using Social.Infrastructure.Data;
namespace Social.Application.UserProfileCQRS.CommandHandlers
{
   public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand>
   {
      private readonly AppDbContext _context;
      public DeleteUserProfileCommandHandler(AppDbContext context)
      {
         _context = context;
      }
      public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
      {
         var profile = await _context.Profiles.Where(p => p.UserProfileId == request.ProfileId).SingleOrDefaultAsync();
         _context.Profiles.Remove(profile);
         await _context.SaveChangesAsync();
         return new Unit();
      }
   }
}