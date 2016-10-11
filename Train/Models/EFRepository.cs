using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Train.Models;

namespace Train.Models {
    public class EFRepository : IEFRepository {
        private ApplicationDbContext _db = new ApplicationDbContext();
        /// <summary> 
                /// Retrieve alltrains. 
                /// </summary> 
        public IList<Cars> ListCars() {
            return _db.Cars.ToList();
        }
        /// <summary> 
                /// Find movie by primary key. 
                /// </summary> 
                /// <param name="id">primary key</param> 
        public Cars Find(int id) {
            return _db.Cars.Find(id);
        }
        /// <summary> 
                /// Add new movie to db. 
                /// </summary> 
        public void CreateCar(Cars carToCreate) {
            _db.Cars.Add(carToCreate);
            _db.SaveChanges();
       
        }
        public void SaveCar(Cars carToSave) {
            if (carToSave.Id == 0) {
                _db.Cars.Add(carToSave);
                _db.SaveChanges();
            } else {
                var original = this.Find(carToSave.Id);
                original.Company = carToSave.Company;
                original.EmptyOrLoaded = carToSave.EmptyOrLoaded;
                original.CarType = carToSave.CarType;
                original.ShippedBy = carToSave.ShippedBy;
                original.RailcarNumber = carToSave.RailcarNumber;
                _db.SaveChanges();
            }
        }
        public void Delete(int id) {
            var car = this.Find(id);
            _db.Cars.Remove(car);
            _db.SaveChanges();
        }
        /// <summary> 
                /// Update existing movie in database. 
                /// </summary> 
        public void UpdateCar(Cars carToUpdate) {
            var originalCar = this.Find(carToUpdate.Id);
            originalCar.Company = carToUpdate.Company;
            originalCar.EmptyOrLoaded = carToUpdate.EmptyOrLoaded;
            originalCar.CarType = carToUpdate.CarType;
            originalCar.ShippedBy = carToUpdate.ShippedBy;
            originalCar.RailcarNumber = carToUpdate.RailcarNumber;
            _db.SaveChanges();
        }
        /// <summary> 
                /// Delete existing movie. 
                /// </summary> 
        public void DeleteCar(int id) {
            var originalCar = this.Find(id);
            _db.Cars.Remove(originalCar);
            _db.SaveChanges();
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
} 
