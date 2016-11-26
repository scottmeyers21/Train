using Train.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Train.ViewModels;

namespace Train.API
{
    public class CarsController : ApiController {
        private RecordRepository _repo;
        public CarsController(RecordRepository repo) {
            this._repo = repo;
        }
        //public IEnumerable<Cars> Get() {
        //    var car = _repo.ListCars();
        //    return car;
        //}
        //public IHttpActionResult Get(int id) {
        //    var match = _repo.FindCar(id);
        //    if (match == null) {
        //        return NotFound();
        //    }
        //    return Ok(match);
        //}

        //[HttpGet]
        //[Route("api/Cars/UserProfile/{userId}")]
        //public IEnumerable<Cars> GetUserCars(string userId) {
        //    var cars = _repo.GetUserCars(userId);
        //    return cars;
        //}

        public IHttpActionResult Post(AddCarsVM data) {
            var userId = User.Identity.GetUserId();
            if (!ModelState.IsValid) {
                return BadRequest(this.ModelState);
            }
            var recordId = data.RecordId;
            var car = data.CarToSave;
            _repo.SaveCar(car, recordId, userId);
            return Created("", car);
        }
        //public IHttpActionResult Delete(int id) {
        //    _repo.Delete(id);
        //    return Ok();
        //}

        //public IHttpActionResult Get(int id) {
        //    var car = _repo.Find(id);
        //    if (car == null) {
        //        return NotFound();
        //    }
        //    return Ok(car);
        //}


    }
}