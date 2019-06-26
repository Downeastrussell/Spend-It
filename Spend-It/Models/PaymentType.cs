using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        [Display(Name = "Name of Cryptocurrency")]
        [StringLength(55, ErrorMessage = "Please shorten the Payment Type Name to 55 characters")]
        public string PaymentTypeName { get; set; }

        public string PaymentTypeTicker { get; set; }
    }
}
