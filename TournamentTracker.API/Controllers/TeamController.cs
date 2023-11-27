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
    public class TeamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITeam _teamService;

        public TeamController(IMapper mapper, ITeam teamService)
        {
            _mapper = mapper;
            _teamService = teamService;
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}", Name = nameof(GetTeamById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<TeamResource>> GetTeamById(int id)
        {

            try
            {
                var team = await _teamService.GetById(id);

                if (team == null)
                {
                    return NotFound();
                }

                var teamResource = _mapper.Map<TeamResource>(team);

                return teamResource;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<TeamController>
        [HttpPost(Name = nameof(CreateTeam))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTeam(TeamResource team)
        {

            if (team == null)
            {
                return BadRequest();
            }

            try
            {
                var teamEntity = _mapper.Map<Team>(team);

                await _teamService.Add(teamEntity);

                //string uri = Url.Link(nameof(CreateTeam), new { team = teamEntity.Id }) ?? string.Empty;

                return Created("", _mapper.Map<TeamResource>(teamEntity));

            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}", Name = nameof(UpdateTeam))]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<ActionResult> UpdateTeam(int id, TeamResource teamResource)
        {
            if (id != teamResource.Id)
            {
                return BadRequest();
            }

            try
            {
                var teamEntity = _mapper.Map<Team>(teamResource);

                await _teamService.Edit(teamEntity);

                return Ok(_mapper.Map<TeamResource>(teamEntity));

            }
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}", Name = nameof(DeleteTeam))]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            try
            {
                var teamEntity = await _teamService.GetById(id);

                if (teamEntity == null)
                {
                    return NotFound();
                }

                await _teamService.Delete(teamEntity);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
