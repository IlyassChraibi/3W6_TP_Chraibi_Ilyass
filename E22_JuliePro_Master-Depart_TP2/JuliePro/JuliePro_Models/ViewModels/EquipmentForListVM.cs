using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class EquipmentForListVM
    {
        public EquipmentForListVM()
        { }
        public EquipmentForListVM(Equipment a)
        {
            Id = a.Id;
            Name = a.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
