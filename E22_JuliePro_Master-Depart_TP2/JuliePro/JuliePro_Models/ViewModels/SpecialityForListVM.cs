using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class SpecialityForListVM
    {
        public SpecialityForListVM()
        { }
        public SpecialityForListVM(Speciality a)
        {
            Id = a.Id;
            Name = a.Name;
            //Trainers = (Trainer)a.Trainers;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        //public Trainer Trainers { get; set; }
    }
}
