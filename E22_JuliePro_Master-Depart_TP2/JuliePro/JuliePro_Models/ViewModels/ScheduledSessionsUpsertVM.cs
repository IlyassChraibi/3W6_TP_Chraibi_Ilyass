using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class ScheduledSessionsUpsertVM
    {
        public ScheduledSessionsUpsertVM()
        { }
        public ScheduledSessionsUpsertVM(bool isCreate, string pageTitle, string pageHeading,
            List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists)
        {
            IsCreate = isCreate;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, submitButtonText);

            ListForTraining_Id = selectLists["ListForTraining_Id"];
            ListForCustomer_Id = selectLists["ListForCustomer_Id"];
        }
        public ScheduledSessionsUpsertVM(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string,
            SelectList­> selectLists, ScheduledSession scheduledSession) : this(isCreate, pageTitle, pageHeading, links, submitButtonText, selectLists)
        {
            ScheduledSession = scheduledSession;
            Id = scheduledSession?.Id;
        }
        public bool IsCreate { get; set; }
        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ScheduledSession ScheduledSession { get; set; }
        public IEnumerable<SelectListItem> ListForTraining_Id { get; set; }
        public IEnumerable<SelectListItem> ListForCustomer_Id { get; set; }
    }
}
