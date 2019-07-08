using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models
{
    public class SavedLocation
    {   [Key]
        [Required]
        public int SavedLocationId { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
