using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1JuliePro_Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name have to be fill")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Should have between 5 to 15 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
