using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Model.DataModels
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string StoreName { get; set; } = default!;
        public virtual IList<Car> Cars { get; set; } = default!;
    }
}