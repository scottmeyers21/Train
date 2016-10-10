using Train.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        public IHttpActionResult Post(Cars car) {
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