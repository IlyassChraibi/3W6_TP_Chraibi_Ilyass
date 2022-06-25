using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainersIndexVM
    {
        public TrainersIndexVM()
        { }
        public TrainersIndexVM(string pageTitle, string pageHeading,
            List<PageLinks> links, ICollection<Trainer> trainers)
        {
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links);
            Trainers = trainers.Select(b => new TrainerForListVM(b)).ToList();
        }

        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ICollection<TrainerForListVM> Trainers { get; set; }
    }
}