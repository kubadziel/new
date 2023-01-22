using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class OwnerCar
    {
        public string CarVin { get; set; } = default!;
        public virtual Car Car { get; set; } = default!;
        public int OwnerId { get; set; } = default!;
        public virtual Owner  Owner{ get; set; } = default!;
    }
}