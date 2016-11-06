using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Train.Models;

namespace Train.API {
    public class RecordController : ApiController {
        private IRecordRepository _repo;
        public RecordController(IRecordRepository repo) {
            this._repo = repo;
        }
        public IHttpActionResult PostRecord(Record record) {
            record.UserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) {
                return BadRequest(this.ModelState);
            }
            _repo.SaveRecord(record);
            return Created("", record);
        }
    }
}