using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class SpecialityForDisplayVM
    {
        public SpecialityForDisplayVM()
        { }
        public SpecialityForDisplayVM(Speciality b)
        {
            Id = b.Id;
            Name = b.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}