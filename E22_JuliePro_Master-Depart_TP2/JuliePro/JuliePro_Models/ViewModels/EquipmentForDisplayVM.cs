using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class EquipmentForDisplayVM
    {
        public EquipmentForDisplayVM()
        { }
        public EquipmentForDisplayVM(Equipment b)
        {
            Id = b.Id;
            Name = b.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
