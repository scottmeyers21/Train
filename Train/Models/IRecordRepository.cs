using System.Collections.Generic;

namespace Train.Models {
    public interface IRecordRepository {
        IList<Record> ListRecords();
        void SaveCar(Cars carToSave, int recordId, string userId);
        void SaveRecord(Record recordToSave);
    }
}