using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainingForDisplayVM
    {
        public TrainingForDisplayVM()
        { }
        public TrainingForDisplayVM(Training b)
        {
            Id = b.Id;
            Category = b.Category;
            Name = b.Name;
        }
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
       
    }
}
