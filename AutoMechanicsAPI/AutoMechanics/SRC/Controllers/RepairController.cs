using AutoMechanics.EFDBContext;
using AutoMechanics.Models;
using AutoMechanics.SRC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMechanics.SRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepairController : ControllerBase
    {
        private readonly AutoMechanicsContext _dbContext;

        public RepairController(AutoMechanicsContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Create a new repair
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        [HttpPost]
        public RepairModel NewRepair([FromBody] RepairModel repair)
        {
            _dbContext.Repairs.Add(repair);
            _dbContext.SaveChanges();
            return repair;
        }

        /// <summary>
        /// Delete a repair by id
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        [HttpDelete()]
        public RepairModel DeleteRepair([FromBody] RepairModel repair)
        {
            _dbContext.Repairs.Remove(GetRepairById(repair.Id));
            _dbContext.SaveChanges();
            return repair;
        }

        /// <summary>
        /// Update a repair
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        [HttpPut()]
        public RepairModel UpdateRepair([FromBody] RepairModel repair)
        {
            var oldRepair = GetRepairById(repair.Id);
            oldRepair.Mechanic = repair.Mechanic;
            oldRepair.Description = repair.Description;
            _dbContext.Repairs.Update(oldRepair);
            _dbContext.SaveChanges();
            return oldRepair;
        }

        /// <summary>
        /// Get a repair by id
        /// </summary>
        /// <param name="idRepair"></param>
        /// <returns></returns>
        [HttpGet("id/idRepair")]
        public RepairModel GetRepairById([FromRoute] int idRepair)
        {
            return _dbContext.Repairs.FirstOrDefault(x => x.Id == idRepair);
        }

        /// <summary>
        /// Get all repairs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<RepairModel> GetAllRepairs()
        {
            return _dbContext.Repairs.ToList();
        }
    }
}
