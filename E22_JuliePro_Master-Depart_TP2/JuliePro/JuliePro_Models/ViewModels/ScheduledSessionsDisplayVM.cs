using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class ScheduledSessionsDisplayVM
    {
        public ScheduledSessionsDisplayVM()
        { }
        public ScheduledSessionsDisplayVM(bool isDetails, string pageTitle, string pageHeading,
            List<PageLinks> links, ScheduledSession scheduledSession, string submitButtonText = "")
        {
            IsDetails = isDetails;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links,
                submitButtonText);
            ScheduledSession = new ScheduledSessionForDisplayVM(scheduledSession);
            Id = scheduledSession.Id;
        }

        public bool IsDetails { get; set; }
        public int Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ScheduledSessionForDisplayVM ScheduledSession { get; set; }
    }
}
