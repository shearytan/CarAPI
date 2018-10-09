using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CarAPI.Entities;
using CarAPI.Models;

namespace CarAPI.Controllers
{
    [Route("api/v1/911_R8/waitlist")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarContext _context;

        public CarController(CarContext context)
        {
            _context = context;

            if (_context.CarItems.Count() == 0)
            {
                _context.CarItems.Add(new CarItem { Firstname = "John", Lastname = "Doe", Name_speak = "Johnny" });
                _context.SaveChanges();
            }
        }

        // GET REQUEST
        [HttpGet]
        public ActionResult<List<CarItem>> GetAll()
        {
            return _context.CarItems.ToList();
        }

        // POST REQUEST
        [HttpPost]
        public IActionResult Create(CarItem item)
        {
            _context.CarItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCar", new { id = item.Id }, item);
        }

        // DELETE REQUEAST
        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            var car = _context.CarItems.Find(Id);
            if (car == null) 
            {
                return NotFound();
            }
            _context.CarItems.Remove(car);
            _context.SaveChanges();
            return NoContent();
        }

        // Put
    }
}