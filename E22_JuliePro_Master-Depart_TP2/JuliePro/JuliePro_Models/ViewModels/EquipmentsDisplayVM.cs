using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class EquipmentsDisplayVM
    {
        public EquipmentsDisplayVM()
        { }
        public EquipmentsDisplayVM(bool isDetails, string pageTitle, string pageHeading,
            List<PageLinks> links, Equipment equipment, string submitButtonText = "")
        {
            IsDetails = isDetails;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links,
                submitButtonText);
            Equipment = new EquipmentForDisplayVM(equipment);
            Id = equipment.Id;
        }

        public bool IsDetails { get; set; }
        public int Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public EquipmentForDisplayVM Equipment { get; set; }
    }
}
