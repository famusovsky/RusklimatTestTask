using System;
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
        public async Task<ActionResult<Manager>> GetManager(uint id)
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
        public async Task<ActionResult<int>> GetManagerSalary(uint id)
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
        /// Gets a all bonuses history from a given period.
        /// </summary>
        /// <param name="from">The date to start the history from.</param>
        /// <param name="to">The date to end the history at.</param>
        /// <returns>A list of all bonuses history.</returns>
        [HttpGet("bonuses")]
        public async Task<ActionResult<IEnumerable<Bonus>>> GetBonusesHistory(DateOnly from = new DateOnly(), DateOnly to = new DateOnly())
        {
            if (from > to)
            {
                return BadRequest(new { message = "The start date must be before the end date." });
            }
            if (from == new DateOnly())
            {
                from = DateOnly.MinValue;
            }
            if (to == new DateOnly())
            {
                to = DateOnly.MaxValue;
            }

            try
            {
                var bonuses = await _repository.GetBonusesHistory(from, to);

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
        /// Gets a manager's bonuses history by id for a given period.
        /// </summary>
        /// <param name="id">The id of the manager to get the bonuses history of.</param>
        /// <param name="from">The date to start the history from.</param>
        /// <param name="to">The date to end the history at.</param>
        /// <returns>The manager's bonuses history with the given id.</returns>
        [HttpGet("{id}/bonuses")]
        public async Task<ActionResult<IEnumerable<Bonus>>> GetBonusesHistory(uint id, DateOnly from = new DateOnly(), DateOnly to = new DateOnly())
        {
            if (from > to)
            {
                return BadRequest(new { message = "The start date must be before the end date." });
            }
            if (from == new DateOnly())
            {
                from = DateOnly.MinValue;
            }
            if (to == new DateOnly())
            {
                to = DateOnly.MaxValue;
            }

            try
            {
                var bonuses = await _repository.GetBonusesHistory(id, from, to);

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
        // TODO: change ID to be generated by the database
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
        /// Updates a manager.
        /// </summary>
        /// <param name="id">The id of the manager to update.</param>
        /// <param name="manager">The manager to update.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateManager(uint id, Manager manager)
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
        public async Task<ActionResult> DeleteManager(uint id)
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

        /// <summary>
        /// Applies call processing to a manager.
        /// </summary>
        /// <param name="id">The id of the manager to apply call processing to.</param>
        /// <param name="count">The number of calls to process.</param>
        /// <param name="date">The date to apply call processing to.</param>
        [HttpPost("{id}/calls")]
        public async Task<ActionResult> ApplyCallProcessing(uint id, uint count = 1, DateOnly date = new DateOnly())
        {
            if (count < 1)
            {
                return BadRequest(new { message = "Count must be greater than 0." });
            }
            if (date == new DateOnly())
            {
                date = DateOnly.FromDateTime(DateTime.Now);
            }

            try
            {
                await _repository.ApplyCallProcessing(id, count, date);

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
        /// Gets a processed calls history for a given period.
        /// </summary>
        /// <param name="from">The date to start the history from.</param>
        /// <param name="to">The date to end the history at.</param>
        /// <returns>The processed calls history.</returns>
        [HttpGet("calls")]
        public async Task<ActionResult<List<ProcessedCallsRecord>>> GetProcessedCallsHistory(DateOnly from = new DateOnly(), DateOnly to = new DateOnly())
        {
            if (from > to)
            {
                return BadRequest(new { message = "The start date must be before the end date." });
            }
            if (from == new DateOnly())
            {
                from = DateOnly.MinValue;
            }
            if (to == new DateOnly())
            {
                to = DateOnly.MaxValue;
            }

            try
            {
                var processedCallsHistory = await _repository.GetProcessedCallsHistory(from, to);

                return Ok(processedCallsHistory);
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
        /// Gets a manager's processed calls history by id for a given period.
        /// </summary>
        /// <param name="id">The id of the manager to get the processed calls history of.</param>
        /// <param name="from">The date to start the history from.</param>
        /// <param name="to">The date to end the history at.</param>
        /// <returns>The manager's processed calls history with the given id.</returns>
        [HttpGet("{id}/calls")]
        public async Task<ActionResult<List<ProcessedCallsRecord>>> GetProcessedCallsHistory(uint id, DateOnly from = new DateOnly(), DateOnly to = new DateOnly())
        {
            if (from > to)
            {
                return BadRequest(new { message = "The start date must be before the end date." });
            }
            if (from == new DateOnly())
            {
                from = DateOnly.MinValue;
            }
            if (to == new DateOnly())
            {
                to = DateOnly.MaxValue;
            }

            try
            {
                var processedCallsHistory = await _repository.GetProcessedCallsHistory(id, from, to);

                return Ok(processedCallsHistory);
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
        /// Gets the total number of processed calls for a given period for a manager with the given id.
        /// </summary>
        /// <param name="id">The id of the manager to get the processed calls count of.</param>
        /// <param name="from">The date to start the history from.</param>
        /// <param name="to">The date to end the history at.</param>
        /// <returns>The total number of processed calls for a given period for a manager with the given id.</returns>
        [HttpGet("{id}/calls/count")]
        public async Task<ActionResult<uint>> GetProcessedCallsCount(uint id, DateOnly from = new DateOnly(), DateOnly to = new DateOnly())
        {
            if (from > to)
            {
                return BadRequest(new { message = "The start date must be before the end date." });
            }
            if (from == new DateOnly())
            {
                from = DateOnly.MinValue;
            }
            if (to == new DateOnly())
            {
                to = DateOnly.MaxValue;
            }

            try
            {
                var processedCallsCount = await _repository.GetCountOfProcessedCalls(id, from, to);

                return Ok(new { id = id, count = processedCallsCount });
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
            }
        }
    }
}
