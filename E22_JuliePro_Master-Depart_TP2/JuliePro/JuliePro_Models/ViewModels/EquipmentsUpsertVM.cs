using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class EquipmentsUpsertVM
    {
        public EquipmentsUpsertVM()
        { }
        public EquipmentsUpsertVM(bool isCreate, string pageTitle, string pageHeading,
            List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists)
        {
            IsCreate = isCreate;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, submitButtonText);

        }
        public EquipmentsUpsertVM(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string,
            SelectList­> selectLists, Equipment equipment) : this(isCreate, pageTitle, pageHeading, links, submitButtonText, selectLists)
        {
            Equipment = equipment;
            Id = equipment?.Id;
        }
        public bool IsCreate { get; set; }
        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public Equipment Equipment { get; set; }
    }
}
