using AutoMechanics.EFDBContext;
using AutoMechanics.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMechanics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly AutoMechanicsContext _dbContext;

        public CarController(AutoMechanicsContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Create a new car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost()]
        public CarModel NewCar([FromBody] CarModel car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
            return car;
        }

        /// <summary>
        /// Delete a car by id
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpDelete()]
        public CarModel DeleteCar([FromBody] CarModel car)
        {
            _dbContext.Cars.Remove(GetCarById(car.Id));
            _dbContext.SaveChanges();
            return car;
        }

        /// <summary>
        /// Update a car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut()]
        public CarModel UpdateCar([FromBody] CarModel car)
        {
            var oldCar = GetCarById(car.Id);
            oldCar.Brand = car.Brand;
            oldCar.Model = car.Model;
            _dbContext.Cars.Update(oldCar);
            _dbContext.SaveChanges();
            return oldCar;
        }

        /// <summary>
        /// Get a car by id
        /// </summary>
        /// <param name="idCar"></param>
        /// <returns></returns>
        [HttpGet("id/idCar")]
        public CarModel GetCarById([FromRoute] int idCar)
        {
            return _dbContext.Cars.FirstOrDefault(x => x.Id == idCar);
        }

        /// <summary>
        /// Get all cars
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IEnumerable<CarModel> GetAllCars()
        {
            return _dbContext.Cars.ToList();
        }
    }
}