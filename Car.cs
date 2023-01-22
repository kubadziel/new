using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Kolokwium.Model.DataModels
{
    public class Car
    {
        [Key]
        public string Vin { get; set; } = default!;
        public int SeatCount { get; set; }
        public int HorsePower { get; set; }
        public virtual IList<OwnerCar> OwnerCars { get; set; } = default!;
        public virtual Store Store { get; set; } = default!;
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        
        
        // public int yearOfBirth {get; set;}
        [NotMapped]
        public int Age => DateTime.Now.Year - yearOfBirth;

    }
}
