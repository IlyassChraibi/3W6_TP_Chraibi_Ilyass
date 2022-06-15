using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1JuliePro_Models
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name have to be fill")]
        [StringLength(25,MinimumLength = 10, ErrorMessage ="Should have between 10 to 25 characters")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name have to be fill")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "Should have between 10 to 25 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Author Email have to be fill")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]                                                                                                                                   
        public string Email { get; set; }
        [Display(Name = "Photo")]
        [StringLength(40)]
        public string Photo { get; set; }

        [ForeignKey("Speciality")]
        public int Speciality_Id { get; set; }
        //OBLIGATOIRE Pour la relation 1 à plusieurs
        public virtual Speciality Speciality { get; set; }
        public bool Active { get; set; }
    }
}
