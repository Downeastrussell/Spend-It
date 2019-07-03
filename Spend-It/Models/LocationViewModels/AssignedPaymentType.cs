using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models.LocationViewModels
{
    public class AssignedPaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeTicker { get; set; }
        public string PaymentTypeName { get; set; }
        public bool Assigned { get; set; }
    }
}
