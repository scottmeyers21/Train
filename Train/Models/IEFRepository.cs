using System.Collections.Generic;

namespace Train.Models {
    public interface IEFRepository {
        void CreateCar(Cars carToCreate);
        void Delete(int id);
        void DeleteCar(int id);
        void Dispose();
        Cars Find(int id);
        IList<Cars> ListCars();
        void SaveCar(Cars carToSave);
        void UpdateCar(Cars carToUpdate);
    }
}