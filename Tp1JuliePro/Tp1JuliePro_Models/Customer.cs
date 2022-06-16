using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1JuliePro_Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "MinLengthValidation")]
        [MaxLength(25, ErrorMessage = "MaxLengthValidation")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "LengthValidation")]
        [MaxLength(25, ErrorMessage = "MaxLengthValidation")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "EmailValidation")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [MaxLength(40, ErrorMessage = "MaxLengthValidation")]
        [Display(Name = "Photo")]
        public string Photo { get; set; }
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "StartWeight")]
        public double? StartWeight { get; set; }

        public virtual ICollection<Customer> Objectives { get; set; }

        [Required]
        [Display(Name = "Trainer")]
        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        //public virtual ICollection<ScheduledSession> Sessions { get; set; }
    }
}
