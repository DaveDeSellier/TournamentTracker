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
    public class PrizeController : ControllerBase
    {

        private readonly IPrize _prizeService;
        private readonly IMapper _mapper;

        public PrizeController(IPrize prizeService, IMapper mapper)
        {
            _prizeService = prizeService;
            _mapper = mapper;
        }

        // GET: api/<PrizeController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<PrizeResource>>> GetAllPrizes()
        {
            try
            {
                var prizes = await _prizeService.List();

                if (prizes == null)
                {
                    return NotFound();
                }

                return _mapper.Map<List<PrizeResource>>(prizes);

            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<PrizeController>/5
        [HttpGet("{id}", Name = nameof(GetPrizeById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PrizeResource>> GetPrizeById(int id)
        {

            try
            {

                var prize = await _prizeService.GetById(id);

                if (prize == null)
                {
                    return NotFound();
                }

                return _mapper.Map<PrizeResource>(prize);

            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<PrizeController>
        [HttpPost(Name = nameof(CreatePrize))]
        [ProducesResponseType(201)]
        public async Task<ActionResult> CreatePrize(PrizeResource prize)
        {


            if (prize == null)
            {
                return BadRequest(prize);
            }

            try
            {

                var prizeModel = _mapper.Map<Prize>(prize);

                await _prizeService.Add(prizeModel);

                var prizeResource = _mapper.Map<PrizeResource>(prizeModel);

                string uri = Url.Link(nameof(GetPrizeById), new { id = prizeResource.Id }) ?? String.Empty;

                return Created(uri, prizeResource);

            }
            catch (Exception)
            {

                throw;
            }

        }

        // PUT api/<PrizeController>/5
        [HttpPut("{id}", Name = nameof(UpdatePrize))]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<ActionResult> UpdatePrize(int id, PrizeResource prizeResource)
        {
            if (id != prizeResource.Id)
            {
                return BadRequest();
            }

            try
            {

                var findPrize = await _prizeService.GetById(id);

                if (findPrize == null)
                {
                    return NotFound();
                }

                var prize = _mapper.Map<Prize>(prizeResource);

                await _prizeService.Edit(prize);

                var updatePrize = _mapper.Map<PrizeResource>(prize);

                return Ok(updatePrize);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE api/<PrizeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                var prize = await _prizeService.GetById(id);

                if (prize == null)
                {
                    return NotFound();
                }
                else
                {
                    await _prizeService.Delete(prize);
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
