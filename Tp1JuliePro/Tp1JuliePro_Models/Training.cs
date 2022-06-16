using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1JuliePro_Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [MinLength(10, ErrorMessage = "MinLengthValidation")]
        [MaxLength(25, ErrorMessage = "MaxLengthValidation")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category")]
        [MinLength(10, ErrorMessage = "MinLengthValidation")]
        [MaxLength(25, ErrorMessage = "MaxLengthValidation")]
        public string Category { get; set; }

        //public virtual ICollection<EquipmentTraining> EquipmentTrainings { get; set; }

        //public virtual ICollection<ScheduledSession> ScheduledSessions { get; set; }

    }
}
