using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainersUpsertVM
    {
        public TrainersUpsertVM()
        { }
        public TrainersUpsertVM(bool isCreate, string pageTitle, string pageHeading, 
            List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists)
        {
            IsCreate = isCreate;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, submitButtonText);

            ListForSpeciality_Id = selectLists["ListForSpeciality_Id"];
        }
        public TrainersUpsertVM(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string,
            SelectList­> selectLists, Trainer trainer) : this(isCreate, pageTitle, pageHeading, links, submitButtonText, selectLists)
        {
            Trainer = trainer;
            Id = trainer?.Id;
        }
        public bool IsCreate { get; set; }
        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public Trainer Trainer { get; set; }
        public IEnumerable<SelectListItem> ListForSpeciality_Id { get; set; }
    }
}
