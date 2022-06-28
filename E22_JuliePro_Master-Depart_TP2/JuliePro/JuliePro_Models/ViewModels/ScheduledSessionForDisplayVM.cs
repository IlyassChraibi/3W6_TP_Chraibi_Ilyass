using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class ScheduledSessionForDisplayVM
    {
        public ScheduledSessionForDisplayVM()
        { }
        public ScheduledSessionForDisplayVM(ScheduledSession b)
        {
            Id = b.Id;
            Complete = b.Complete;
            Customer_Id = b.Customer_Id;
            Date = b.Date;
            Description = b.Description;
            Detail = b.Detail;
            DurationMin = b.DurationMin;
            Training_Id = b.Training_Id;
            WithTrainer = b.WithTrainer;
        }
        public int Id { get; set; }
        public bool? Complete { get; set; }
        public int Customer_Id { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int? DurationMin { get; set; }
        public int? Training_Id { get; set; }
        public bool? WithTrainer {get;set; }
    }
}
