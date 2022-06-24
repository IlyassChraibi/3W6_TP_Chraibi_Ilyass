using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class SpecialitiesDisplayVM
    {
        public SpecialitiesDisplayVM()
        { }
        public SpecialitiesDisplayVM(bool isDetails, string pageTitle, string pageHeading, 
            List<PageLinks> links, Speciality speciality, string submitButtonText = "")
        {
            IsDetails = isDetails;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, 
                submitButtonText);
            Speciality = new SpecialityForDisplayVM(speciality);
            Id = speciality.Id;
        }

        public bool IsDetails { get; set; }
        public int Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public SpecialityForDisplayVM Speciality { get; set; }
    }
}
