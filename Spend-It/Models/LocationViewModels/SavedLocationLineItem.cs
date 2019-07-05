using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models.LocationViewModels
{
    public class SavedLocationLineItem
    {
        public Location Location { get; set; }
        public IEnumerable<PaymentType> PaymentTypes { get; set; }
    }
}
