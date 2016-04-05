namespace WebServiceDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoomFacility
    {
        [Key]
        public int RoomFacilities_ID { get; set; }

        public int Facilities_No { get; set; }

        public int Room_No { get; set; }

        public int Hotel_No { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual Room Room { get; set; }
    }
}
