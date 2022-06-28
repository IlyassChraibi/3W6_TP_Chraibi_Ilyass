using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class ScheduledSessionForListVM
    {
        public ScheduledSessionForListVM()
        { }
        public ScheduledSessionForListVM(ScheduledSession a)
        {
            Id = a.Id;
            Complete = a.Complete;
            Customer_Id = a.Customer_Id;
            Date = a.Date;
            Description = a.Description;
            Detail = a.Detail;
            DurationMin = a.DurationMin;
            Training_Id = a.Training_Id;
            WithTrainer = a.WithTrainer;
        }
        public int Id { get; set; }
        public bool? Complete { get; set; }
        public int Customer_Id { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int? DurationMin { get; set; }
        public int? Training_Id { get; set; }
        public bool? WithTrainer { get; set; }
    }
}
