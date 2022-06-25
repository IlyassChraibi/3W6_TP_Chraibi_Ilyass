using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainingsIndexVM
    {
        public TrainingsIndexVM()
        { }
        public TrainingsIndexVM(string pageTitle, string pageHeading,
            List<PageLinks> links, ICollection<Training> training)
        {
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links);
            Trainings = training.Select(b => new TrainingForListVM(b)).ToList();
        }

        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ICollection<TrainingForListVM> Trainings { get; set; }
    }
}
