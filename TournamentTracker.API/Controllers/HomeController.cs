using Microsoft.AspNetCore.Mvc;
using TournamentTracker.API.Models;
using TournamentTracker.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TournamentTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ITournament _tournamentService;
        public HomeController(ITournament tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // GET: api/Home
        [HttpGet(Name = nameof(GetTournaments))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<TournamentResource>>> GetTournaments()
        {

            throw new NotImplementedException();

        }

        // GET: api/Home/{id}
        [HttpGet("{id}", Name = nameof(GetTournamentById))]
        public async Task<ActionResult<TournamentResource>> GetTournamentById(int id)
        {

            var tournament = await _tournamentService.GetById(id);

            if (tournament == null)
            {
                return NotFound();
            }

            TournamentResource resource = new()
            {
                TournamentName = tournament.TournamentName,
                EntryFee = tournament.EntryFee,
                Href = Url.Link(nameof(GetTournamentById), null)
            };

            return resource;
        }

    }
}
