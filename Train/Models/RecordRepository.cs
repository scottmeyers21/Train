using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Train.Models {
    public class RecordRepository : IRecordRepository {

        private ApplicationDbContext _db = new ApplicationDbContext();
        /// <summary> 
                /// Retrieve alltrains. 
                /// </summary> 

        public IList<Record> ListRecords() {
            return _db.Record.ToList();
        }
        public void SaveRecord(Record recordToSave) {
            
            if (recordToSave.Id == 0) {
                recordToSave.DateCreated = DateTime.Now;
                _db.Record.Add(recordToSave);
                _db.SaveChanges();

            } else {
                var original = this._db.Record.Find(recordToSave.Id);
                original.Quantity = recordToSave.Quantity;
                original.IsActive = true;
                
                _db.SaveChanges();
            }
        }
    }
}