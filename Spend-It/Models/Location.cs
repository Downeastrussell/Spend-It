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
        [Display(Name = "Short Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Name of Establishment")]
        [StringLength(55, ErrorMessage = "Please shorten the Name of the Establishment to 55 characters")]
        public string LocationName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
       
        public City City { get; set; }

        [Required]
        [Display(Name = "Type of Establishment")]
        public int LocationTypeId { get; set; }

        [Display(Name = "Type of Establishment")]
        public LocationType LocationType { get; set; }


        public virtual ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
