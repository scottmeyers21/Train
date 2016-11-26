using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Train.Models {
    public class Cars {
        public int Id { get; set; }
        public string EmptyOrLoaded { get; set; }
        public string CarType { get; set; }
        //Hopper, flatbed, tank, gondola, etc.
        public string ShippedBy { get; set; }
        //UP(Union Pacific) or BNSF
        public string RailcarNumber { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }   
        public virtual Record Record { get; set; }
    
    }
}