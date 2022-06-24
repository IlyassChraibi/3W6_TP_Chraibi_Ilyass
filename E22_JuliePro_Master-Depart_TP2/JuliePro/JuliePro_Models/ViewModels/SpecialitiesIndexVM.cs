using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class SpecialitiesIndexVM
    {
        public SpecialitiesIndexVM()
        { }
        public SpecialitiesIndexVM(string pageTitle, string pageHeading,
            List<PageLinks> links, ICollection<Speciality> specialities)
        {
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links);
            Specialities = specialities.Select(b => new SpecialityForListVM(b)).ToList();
        }

        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ICollection<SpecialityForListVM> Specialities { get; set; }
    }
}
