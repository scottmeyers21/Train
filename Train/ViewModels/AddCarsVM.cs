using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Train.Models;

namespace Train.ViewModels {
    public class AddCarsVM {
        public Cars CarToSave { get; set; }
        public int RecordId { get; set; }
    }
}