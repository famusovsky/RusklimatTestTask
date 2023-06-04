using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employment.DBHandling.Repositories;
using Employment.Models;

namespace Employment.Controllers
{
    /// <summary>
    /// This class is responsible for configuring the API endpoints for the Managers module ("*/managers").
    /// </summary>
    [ApiController]
    [Route("managers")]
    public class ManagersController : ControllerBase
    {
        private readonly IManagementRepository _repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagersController"/> class.
        /// </summary>
        /// <param name="repository">The managers repository.</param>
        public ManagersController(IManagementRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets all managers.
        /// </summary>
        /// <returns>A list of all managers.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            try
            {
                var managers = await _repository.GetManagers();

                return Ok(managers);
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
        /// Gets a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to get.</param>
        /// <returns>The manager with the given id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            try
            {
                var manager = await _repository.GetManager(id);

                return Ok(manager);
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
        /// Gets a manager's salary by id.
        /// </summary>
        /// <param name="id">The id of the manager to get the salary of.</param>
        /// <returns>The manager's salary with the given id.</returns>
        [HttpGet("{id}/salary")]
        public async Task<ActionResult<int>> GetManagerSalary(int id)
        {
            try
            {
                var salary = await _repository.GetManagerSalary(id);

                return Ok(new { id = id, salary = salary });
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
        /// Gets a all bonuses history.
        /// </summary>
        /// <returns>A list of all bonuses history.</returns>
        [HttpGet("bonuses")]
        public async Task<ActionResult<IEnumerable<Bonus>>> GetBonusesHistory()
        {
            try
            {
                var bonuses = await _repository.GetBonusesHistory();

                return Ok(bonuses);
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
        /// Gets a manager's bonuses history by id.
        /// </summary>
        /// <param name="id">The id of the manager to get the bonuses history of.</param>
        /// <returns>The manager's bonuses history with the given id.</returns>
        [HttpGet("{id}/bonuses")]
        public async Task<ActionResult<IEnumerable<Bonus>>> GetBonusesHistory(int id)
        {
            try
            {
                var bonuses = await _repository.GetBonusesHistory(id);

                return Ok(bonuses);
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
        /// Adds a manager.
        /// </summary>
        /// <param name="manager">The manager to add.</param>
        [HttpPost]
        public async Task<ActionResult> AddManager(Manager manager)
        {
            try
            {
                await _repository.AddManager(manager);

                return Created($"/managers/{manager.Id}", new { Message = $"Manager {manager.Id} created successfully." });
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

        /// <summary>
        /// Applies call processing to a manager.
        /// </summary>
        /// <param name="id">The id of the manager to apply call processing to.</param>
        [HttpPost("{id}/call")]
        public async Task<ActionResult> ApplyCallProcessing(int id)
        {
            try
            {
                await _repository.ApplyCallProcessing(id);

                return Ok(new { message = $"Manager {id} processed call successfully." });
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
        /// Updates a manager.
        /// </summary>
        /// <param name="id">The id of the manager to update.</param>
        /// <param name="manager">The manager to update.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateManager(int id, Manager manager)
        {
            try
            {
                await _repository.UpdateManager(id, manager);

                return Accepted($"/managers/{id}", new { Message = $"Manager {id} updated successfully." });
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
        /// Deletes a manager.
        /// </summary>
        /// <param name="id">The id of the manager to delete.</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManager(int id)
        {
            try
            {
                await _repository.DeleteManager(id);

                return Accepted($"/managers/{id}", new { Message = $"Manager {id} deleted successfully." });
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
