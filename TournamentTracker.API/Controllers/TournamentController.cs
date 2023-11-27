using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentTracker.API.Models;
using TournamentTracker.Core.Interfaces;
using TournamentTracker.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TournamentTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private readonly ITournament _tournamentService;
        private readonly IMapper _mapper;
        public TournamentController(ITournament tournamentService, IMapper mapper)
        {
            _tournamentService = tournamentService;
            _mapper = mapper;

        }

        // GET: api/Tournament
        [HttpGet(Name = nameof(GetTournaments))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<PartialTournamentResource>>> GetTournaments()
        {

            var tournaments = await _tournamentService.List();

            if (tournaments == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<PartialTournamentResource>>(tournaments);

        }

        // GET: api/Tournament/{id}
        [HttpGet("{id}", Name = nameof(GetTournamentById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<TournamentResource>> GetTournamentById(int id)
        {

            var tournament = await _tournamentService.GetById(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return _mapper.Map<TournamentResource>(tournament);

        }

        // POST: api/Tournament
        [HttpPost(Name = nameof(CreateTournament))]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        public async Task<ActionResult<TournamentResource>> CreateTournament(TournamentResource tournamentResource)
        {

            try
            {
                var tournament = _mapper.Map<Tournament>(tournamentResource);

                await _tournamentService.Add(tournament);

                var createdTournament = _mapper.Map<TournamentResource>(tournament);

                //string uri = Url.Link($"{nameof(createdTournament)}", new { Id = createdTournament.Id }) ?? string.Empty;

                return Created("", createdTournament);

            }
            catch (Exception)
            {
                throw;
            }

        }

        // PUT: api/Tournament/{id}
        [HttpPut("{id}", Name = nameof(AddMatchup))]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddMatchup(int id, PartialTournamentResource tournamentResource)
        {

            if (id != tournamentResource.Id)
            {
                return BadRequest();
            }

            //Calling the same service again causes entity conflicts. Handle all context updates in a single unit of work in the infrastructure layer.

            try
            {

                var updatedTournament = _mapper.Map<Tournament>(tournamentResource);

                await _tournamentService.Edit(updatedTournament);

                var tournamentView = _mapper.Map<PartialTournamentResource>(updatedTournament);

                return Ok(tournamentView);
            }
            catch (Exception)
            {
                throw;
            }

        }


        // DELETE: api/Tournament/{id}
        [HttpDelete("{id}", Name = nameof(DeleteTournament))]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteTournament(int id)
        {

            try
            {
                var tournament = await _tournamentService.GetById(id);

                if (tournament == null)
                {
                    return NotFound();
                }

                await _tournamentService.Delete(tournament);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
