namespace WebServiceDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        public int Hotel_No { get; set; }

        [Required]
        [StringLength(30)]
        public string Hotel_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Hotel_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }

        //public override string ToString()
        //{
        //    return ("Hotel :" + Hotel_No + "Name: \n"+ Hotel_Name + "\tAddress" + Hotel_Address);
        //}
    }
}
