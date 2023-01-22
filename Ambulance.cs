using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Ambulance : Car
    {
        public string SirensColor { get; set; } = default!;
    }
}