using System.Collections.Generic;
using Train.Models;

namespace Train.Models {
    public interface IRecordRepository {
        IList<Record> ListRecords();
        void SaveRecord(Record recordToSave);
    }
}