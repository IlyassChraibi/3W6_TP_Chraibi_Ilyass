using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class SpecialityVM
    {
        public SpecialityVM()
        {

        }
        public int Id { get; set; }

        [Display(Name = "SpecialityName")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "MinMaxLengthValidation")]
        public string Name { get; set; }

        public List<Trainer> Trainers { get; set; }
    }
}
