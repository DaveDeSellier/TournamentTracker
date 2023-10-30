using Microsoft.AspNetCore.Mvc;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

namespace TournamentTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private readonly ITournament _tournamentService;

        public TournamentController(ITournament tournamentService)
        {
            _tournamentService = tournamentService;
        }

        //GET 
        [HttpGet]
        public async Task<ActionResult<Tournament>> GetTournamentById(int id)
        {
            try
            {

                var tournament = _tournamentService.GetById(id);

                if (tournament == null)
                {

                    return NotFound();
                }

                return Created($"/tournament/{tournament.Id}", tournament);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        // POST: CreateTournamentController/Create
        [HttpPost]
        public async Task<ActionResult> CreateTournament(Tournament tournament)
        {

            try
            {

                if (tournament == null)
                {

                    return BadRequest(tournament);
                }

                await _tournamentService.Add(tournament);
                return Created($"/tournament/{tournament.Id}", tournament);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
