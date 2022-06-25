using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class EquipmentsIndexVM
    {
        public EquipmentsIndexVM()
        { }
        public EquipmentsIndexVM(string pageTitle, string pageHeading,
            List<PageLinks> links, ICollection<Equipment> equipments)
        {
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links);
            Equipments = equipments.Select(b => new EquipmentForListVM(b)).ToList();
        }

        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ICollection<EquipmentForListVM> Equipments { get; set; }
    }
}
