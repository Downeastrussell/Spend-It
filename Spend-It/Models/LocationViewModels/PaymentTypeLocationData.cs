using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models.LocationViewModels
{
    public class PaymentTypeLocationData
    {
        public List<Location> Locations { get; set; }
        public IEnumerable<PaymentType> PaymentTypes { get; set; }

        public IEnumerable<SavedLocation> SavedLocations { get; set; }
    }
}
