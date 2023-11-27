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
    public class MatchupController : ControllerBase
    {
        private readonly IMatchup _matchUpService;
        private readonly IMapper _mapper;
        public MatchupController(IMatchup matchUpService, IMapper mapper)
        {
            _matchUpService = matchUpService;
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet(Name = nameof(GetMatchups))]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<MatchupResource>>> GetMatchups()
        {
            var matchups = await _matchUpService.List();

            return _mapper.Map<List<MatchupResource>>(matchups);

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = nameof(GetMatchupById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<MatchupResource>> GetMatchupById(int id)
        {
            var matchup = await _matchUpService.GetById(id);

            if (matchup == null)
            {
                return NotFound();
            }

            return _mapper.Map<MatchupResource>(matchup);

        }

        // POST api/<ValuesController>
        [HttpPost(Name = nameof(CreateMatchup))]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        public async Task<ActionResult> CreateMatchup(MatchupResource matchupResource)
        {

            if (matchupResource == null)
            {
                return BadRequest();
            }

            try
            {

                var matchup = _mapper.Map<Matchup>(matchupResource);

                await _matchUpService.Add(matchup);

                var returnResource = _mapper.Map<MatchupResource>(matchup);

                //string uri = Url.Link(nameof(CreateMatchup), new { Id = returnResource.Id }) ?? string.Empty;

                return Created("", returnResource);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
