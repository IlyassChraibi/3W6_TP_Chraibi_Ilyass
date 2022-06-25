using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainersDisplayVM
    {
        public TrainersDisplayVM()
        { }
        public TrainersDisplayVM(bool isDetails, string pageTitle, string pageHeading, 
            List<PageLinks> links, Trainer trainer, string submitButtonText = "")
        {
            IsDetails = isDetails;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links,
                submitButtonText);
            Trainer = new TrainerForDisplayVM(trainer);
            Id = trainer.Id;
        }

        public bool IsDetails { get; set; }
        public int Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public TrainerForDisplayVM Trainer { get; set; }
    }
}
