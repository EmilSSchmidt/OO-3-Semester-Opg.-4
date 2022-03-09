using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Obligatorisk_Opgave_3_semester;
using OO_3_Semester_Opg._4_version._2.Managers;




namespace OO_3_Semester_Opg._4_version._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarsManager _manager = new CarsManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string substring, [FromQuery] int maximumPrice)
        {
            IEnumerable<Car> car = null; 
            car = _manager.GetAll(substring,maximumPrice);

            if (!car.Any())
            {
                return NotFound("No Car Found");
            }
            return Ok(car);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarsOnId(int id)
        {
            Car  car = _manager.GetById(id);
            if (car == null) return NotFound("No such car, id: " + id);
            return Ok(car);
        }

        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car value)
        {
            
            if (value.Model == null || value.Price <= 0 || value.Licenseplate == null)
            {
                return BadRequest(value);
            }

            Car car = _manager.AddCar(value);
            return Created($"/api/Car/" + car.Id, car);
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null) return NotFound("No such car, id: " + id);
            return Ok(_manager.Delete(id));
        }


    }
}
