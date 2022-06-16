using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1JuliePro_Models;

namespace JuliePro_Models
{
    public class ScheduledSession
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Detail")]
        [MinLength(10, ErrorMessage = "MinLengthValidation")]
        [MaxLength(25, ErrorMessage = "MaxLengthValidation")]
        public string Detail { get; set; }


        [Required]
        [Display(Name = "Description")]
        [MinLength(10, ErrorMessage = "MinLengthValidation")]
        [MaxLength(25, ErrorMessage = "MaxLengthValidation")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "DurationMinutes")]
        [Range(20, 90, ErrorMessage = "RangeValidation")]
        public int DurationMin { get; set; }
        [Display(Name = "Withtrainer")]
        [NotMapped]
        public bool? WithTrainer {  get { return this.TrainerId != null; } set { } }


        [Display(Name = "Completed")]
        public bool? Complete { get; set; }

        [Required]
        [Display(Name = "Customer")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [Display(Name = "Training")]
        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }


        [Display(Name = "Trainer")]
        [ForeignKey("Trainer")]
        public int? TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

    }
}
