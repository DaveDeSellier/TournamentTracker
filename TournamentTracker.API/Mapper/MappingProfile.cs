using AutoMapper;
using TournamentTracker.API.Models;
using TournamentTracker.Core.Models;

namespace TournamentTracker.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tournament, TournamentResource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EntryFee, opt => opt.MapFrom(src => src.EntryFee))
                .ForMember(dest => dest.TournamentName, opt => opt.MapFrom(src => src.TournamentName))
                .ForMember(dest => dest.TournamentPrizes, opt => opt.MapFrom(src => src.TournamentPrizes))
                .ForMember(dest => dest.TournamentEntries, opt => opt.MapFrom(src => src.TournamentEntries))
                .ForMember(dest => dest.Matchups, opt => opt.MapFrom(src => src.Matchups))
                .ReverseMap();
            //.ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.HomeController.GetTournamentById), new { Id = src.Id })));

            CreateMap<Tournament, PartialTournamentResource>()
                .ReverseMap();

            CreateMap<TournamentPrize, TournamentPrizeResource>();

            CreateMap<Prize, PrizeResource>()
                .ReverseMap();

            CreateMap<Team, TeamResource>()
                .ReverseMap();

            CreateMap<TeamMember, TeamMemberResource>()
                .ReverseMap();

            CreateMap<TournamentEntry, TournamentEntryResource>()
                .ReverseMap();

            CreateMap<Matchup, MatchupResource>()
                .ReverseMap();

            CreateMap<MatchupEntry, MatchupResource>()
                .ReverseMap();

            CreateMap<Person, PersonResource>()
                .ReverseMap();

        }
    }
}
