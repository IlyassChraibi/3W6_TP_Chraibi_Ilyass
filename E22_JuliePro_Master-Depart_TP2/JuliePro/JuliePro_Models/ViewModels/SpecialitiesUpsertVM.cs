using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class SpecialitiesUpsertVM
    {
        public SpecialitiesUpsertVM()
        { }
        public SpecialitiesUpsertVM(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists)
        {
            IsCreate = isCreate;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, submitButtonText);
            ListForSubject_Id = selectLists["ListForSubject_Id"];
            ListForPublisher_Id = selectLists["ListForPublisher_Id"];
        }
        public SpecialitiesUpsertVM(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists, Speciality speciality) : this(isCreate, pageTitle, pageHeading, links, submitButtonText, selectLists)
        {
            Speciality = speciality;
            Id = speciality?.Id;
        }
        public bool IsCreate { get; set; }
        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public Speciality Speciality { get; set; }
        public IEnumerable<SelectListItem> ListForSubject_Id { get; set; }
        public IEnumerable<SelectListItem> ListForPublisher_Id { get; set; }
    }
}
