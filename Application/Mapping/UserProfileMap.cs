using AutoMapper;
using Social.Application.UserProfileCQRS.Commands;
using Social.Domain.ValueObjects.UserProfile;

namespace Social.Application.Mapping
{
   internal class UserProfileMap : Profile
   {
      public UserProfileMap()
      {
         CreateMap<CreateUserProfileCommand, BasicInfo>().ReverseMap();
      }
   }
}