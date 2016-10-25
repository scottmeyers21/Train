using Train.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Train.API
{
    public class CarsController : ApiController {
        private IEFRepository _repo;
        public CarsController(IEFRepository repo) {
            this._repo = repo;
        }
        public IEnumerable<Cars> Get() {
            var car = _repo.ListCars();
            return car;
        }

        [HttpGet]
        [Route("api/Cars/ListUserCars/{userId}")]
        public IEnumerable<Cars> GetUserCars(string userId) {
            var cars = _repo.GetUserCars(userId);
            return cars;
        }

        public IHttpActionResult Post(Cars car) {
            car.UserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) {
                return BadRequest(this.ModelState);
            }
            _repo.SaveCar(car);
            return Created("", car);
        }
        public IHttpActionResult Delete(int id) {
            _repo.Delete(id);
            return Ok();
        }

        public IHttpActionResult Get(int id) {
            var car = _repo.Find(id);
            if (car == null) {
                return NotFound();
            }
            return Ok(car);
        }


    }
}