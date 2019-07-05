using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models
{
    public class LocationType
    {
        [Key]
        public int LocationTypeId { get; set; }

        [Required]
        [Display(Name = "Type of Establishment")]
        [StringLength(55, ErrorMessage = "Please shorten the Location Type Name to 55 characters")]
        public string LocationTypeName { get; set; }

        
    }
}
