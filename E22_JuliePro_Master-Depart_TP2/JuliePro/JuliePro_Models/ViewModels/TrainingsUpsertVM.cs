using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainingsUpsertVM
    {
        public TrainingsUpsertVM()
        { }
        public TrainingsUpsertVM(bool isCreate, string pageTitle, string pageHeading,
            List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists)
        {
            IsCreate = isCreate;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, submitButtonText);
        }
        public TrainingsUpsertVM(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string,
            SelectList­> selectLists, Training training) : this(isCreate, pageTitle, pageHeading, links, submitButtonText, selectLists)
        {
            Training = training;
            Id = training?.Id;
        }
        public bool IsCreate { get; set; }
        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public Training Training { get; set; }
    }
}
