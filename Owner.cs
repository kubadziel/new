using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Kolokwium.Model.DataModels
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public virtual IList<OwnerCar> OwnerCars { get; set; } = default!;

    }
}