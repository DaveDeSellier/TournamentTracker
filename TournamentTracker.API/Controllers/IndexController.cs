using Microsoft.AspNetCore.Mvc;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

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

        // GET: api/<ValuesController>
        [HttpGet(Name = nameof(GetTournaments))]
        public async Task<ActionResult<List<Tournament>>> GetTournaments()
        {

            var tournaments = await _tournamentService.List();

            if (tournaments == null)
            {
                return NotFound();
            }

            return tournaments;

        }

        // GET: api/<ValuesController>
        [HttpGet("id")]
        public async Task<ActionResult<Tournament>> GetTournamentById(int id)
        {

            throw new NotImplementedException();
        }

    }
}
