
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Train.Models;
using System.Threading.Tasks;
using System.Text;
using Ninject.Selection;
using Train.ViewModels;

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
        public void SaveCar(Cars carToSave, int recordId, string userId) {
            var user = _db.Users.Find(userId);
            if (carToSave.Id == 0) {
                carToSave.Record = _db.Record.Find(recordId);
                carToSave.UserId = user.Id;
                _db.Cars.Add(carToSave);
                _db.SaveChanges();
            } else {
                var original = _db.Cars.Find(carToSave.Id);
                original.Record = _db.Record.Find(recordId);
                original.CarType = carToSave.CarType;
                original.EmptyOrLoaded = carToSave.EmptyOrLoaded;
                original.RailcarNumber = carToSave.RailcarNumber;
                original.ShippedBy = carToSave.ShippedBy;
            }


        }




        }
        //public IList<Record> FindRecordWithCars(int id) {

        //    return _db.Cars.Where(c =>((c.RecordId == id)).ToList();
           
        //}
    
}
