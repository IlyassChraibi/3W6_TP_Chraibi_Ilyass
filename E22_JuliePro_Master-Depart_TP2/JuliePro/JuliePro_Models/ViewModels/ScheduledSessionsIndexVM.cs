using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class ScheduledSessionsIndexVM
    {
        public ScheduledSessionsIndexVM()
        { }
        public ScheduledSessionsIndexVM(string pageTitle, string pageHeading,
            List<PageLinks> links, ICollection<ScheduledSession> scheduledSessions)
        {
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links);
            ScheduledSessions = scheduledSessions.Select(b => new ScheduledSessionForListVM(b)).ToList();
        }

        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ICollection<ScheduledSessionForListVM> ScheduledSessions { get; set; }
    }
}
