using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1JuliePro_Models
{
    public class Objective
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "MinLengthValidation")]
        [MaxLength(15, ErrorMessage = "MaxLengthValidation")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Range(2, 10, ErrorMessage = "RangeValidation")]
        [Display(Name = "LostWeight")]
        public double? LostWeight { get; set; }
        [Range(2, 45, ErrorMessage = "RangeValidation")]
        [Display(Name = "DistanceKm")]
        public double? DistanceKm { get; set; }
        [Required]
        [Display(Name = "AchievedDate")]
        public DateTime AchievedDate { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
