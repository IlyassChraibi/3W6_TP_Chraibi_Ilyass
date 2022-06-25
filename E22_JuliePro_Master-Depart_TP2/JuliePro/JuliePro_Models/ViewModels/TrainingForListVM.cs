using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainingForListVM
    {
        public TrainingForListVM()
        { }
        public TrainingForListVM(Training a)
        {
            Id = a.Id;
            Name = a.Name;
            Category =  a.Category;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
