using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employment.DBHandling.Repositories;
using Employment.Models;

namespace Employment.Controllers
{
    /// <summary>
    /// This class represents the Premiums module's API endpoints.
    /// </summary>
    [ApiController]
    [Route("premiums")]
    public class PremiumsController : ControllerBase
    {
        private readonly IPremiumsRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="PremiumsController"/> class.
        /// </summary>
        /// <param name="repository">The database repository.</param>
        public PremiumsController(IPremiumsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all premiums.
        /// </summary>
        /// <returns>A list of all premiums.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiums()
        {
            try
            {
                var premiums = await _repository.GetPremiums();

                return Ok(premiums);
            }
            catch (System.ArgumentException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
            }
        }

        /// <summary>
        /// Gets a premium by id.
        /// </summary>
        /// <param name="id">The id of the premium to get.</param>
        /// <returns>The premium with the given id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Premium>> GetPremium(int id)
        {
            try
            {
                var premium = await _repository.GetPremium(id);

                return Ok(premium);
            }
            catch (System.ArgumentException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
            }
        }

        /// <summary>
        /// Gets all premiums for an employee.
        /// </summary>
        /// <param name="id">The id of the employee.</param>
        /// <returns>A list of all premiums for the employee.</returns>
        [HttpGet("employee/{id}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumsForEmployee(uint id)
        {
            try
            {
                var premiums = await _repository.GetPremiums(id);

                return Ok(premiums);
            }
            catch (System.ArgumentException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
            }
        }

        /// <summary>
        /// Adds a premium.
        /// </summary>
        /// <param name="premium">The premium to add.</param>
        [HttpPost]
        public async Task<ActionResult> AddPremium(Premium premium)
        {
            try
            {
                await _repository.AddPremium(premium);

                return Created($"/premiums/{premium.Id}", new { Message = $"Premium {premium.Id} created successfully." });
            }
            catch (System.ArgumentException e)
            {
                return Conflict(new { message = e.Message });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
            }
        }

        // TODO: not just change all fields, but only the ones that are passed in
        /// <summary>
        /// Updates a premium.
        /// </summary>
        /// <param name="id">The id of the premium to update.</param>
        /// <param name="premium">The premium to update.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePremium(int id, Premium premium)
        {
            try
            {
                await _repository.UpdatePremium(id, premium);

                return Accepted($"/premiums/{id}", new { Message = $"Premium {id} updated successfully." });
            }
            catch (System.ArgumentException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
            }
        }

        /// <summary>
        /// Deletes a premium.
        /// </summary>
        /// <param name="id">The id of the premium to delete.</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePremium(int id)
        {
            try
            {
                await _repository.DeletePremium(id);

                return Accepted($"/premiums/{id}", new { Message = $"Premium {id} deleted successfully." });
            }
            catch (System.ArgumentException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
            }
        }
    }
}
