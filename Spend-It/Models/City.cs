using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Name of City")]
        [StringLength(55, ErrorMessage = "Please shorten the City Name 55 characters")]
        public string CityName { get; set; }
    }
}
