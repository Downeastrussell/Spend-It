using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models
{
    public class PaymentTypeLocation
    {
        [Required]
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }
     
    }
}
