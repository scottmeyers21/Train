using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Train.Models {
    public class Record {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Cars> Cars { get; set; }
    }
}