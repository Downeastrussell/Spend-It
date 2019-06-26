using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Name of Establishment")]
        [StringLength(55, ErrorMessage = "Please shorten the Name of the Establishment to 55 characters")]
        public string LocationName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int CityId { get; set; }
        [Required]
        public City City { get; set; }

        [Required]
        public int LocationTypeId { get; set; }
        [Required]
        public LocationType LocationType { get; set; }


        public virtual ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
