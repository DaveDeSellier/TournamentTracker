using Microsoft.AspNetCore.Mvc;
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

        public PrizeController(IPrize prizeService)
        {
            _prizeService = prizeService;
        }

        // GET: api/<PrizeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PrizeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrizeController>
        [HttpPost]
        public async Task<ActionResult> Post(Prize prize)
        {


            if (prize == null)
            {
                return BadRequest(prize);
            }

            try
            {
                await _prizeService.Add(prize);
                return Created("", prize);

            }
            catch (Exception)
            {

                throw;
            }

        }

        // PUT api/<PrizeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrizeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
