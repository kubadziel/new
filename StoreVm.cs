using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Model.DataModels;

namespace Kolokwium.ViewModels.VM
{
    public class StoreVm
    {
        public int Id { get; set; }
        public string StoreName { get; set; } = default!;
    }
}