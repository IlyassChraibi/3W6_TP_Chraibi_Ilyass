using JuliePro_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1JuliePro_Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [MinLength(5, ErrorMessage = "MinLengthValidation")]
        [MaxLength(150, ErrorMessage = "MaxLengthValidation")]
        public string Name { get; set; }

        public virtual ICollection<EquipmentTraining> EquipmentTrainings { get; set; }
    }
}
