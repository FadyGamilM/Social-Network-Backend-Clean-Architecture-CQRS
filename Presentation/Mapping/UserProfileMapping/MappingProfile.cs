using Social.Presentation.Contracts.ProfileContracts.Requests;
using Social.Presentation.Contracts.ProfileContracts.Responses;
using Social.Application.UserProfileCQRS.Commands;
using Social.Domain.Aggregates.UserProfileAggregate;
using AutoMapper;
using Social.Domain.ValueObjects.UserProfile;

namespace Social.Presentation.Mapping.UserProfileMapping
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<CreateProfile, CreateUserProfileCommand>().ReverseMap();
         //* for returning back the response to the client we need to covert the 
         //* domain entity into the contract response we defined in API layer
         CreateMap<UserProfile, GetProfile>().ReverseMap();
         CreateMap<Presentation.Contracts.ProfileContracts.Responses.BasicInfo,
                               Domain.ValueObjects.UserProfile.BasicInfo>().ReverseMap();
      }
   }
}