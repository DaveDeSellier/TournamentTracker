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
                .ReverseMap();
            //.ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.HomeController.GetTournamentById), new { Id = src.Id })));

            CreateMap<Tournament, PartialTournamentResource>()
                .ReverseMap();

            CreateMap<TournamentPrize, TournamentPrizeResource>()
                .ReverseMap();

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

            CreateMap<MatchupEntry, MatchupEntryResource>()
                .ReverseMap();

            CreateMap<Person, PersonResource>()
                .ReverseMap();

        }
    }
}
