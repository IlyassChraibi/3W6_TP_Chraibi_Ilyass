using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainingsDisplayVM
    {
        public TrainingsDisplayVM()
        { }
        public TrainingsDisplayVM(bool isDetails, string pageTitle, string pageHeading,
            List<PageLinks> links, Training training, string submitButtonText = "")
        {
            IsDetails = isDetails;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links,
                submitButtonText);
            Training = new TrainingForDisplayVM(training);
            Id = training.Id;
        }

        public bool IsDetails { get; set; }
        public int Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public TrainingForDisplayVM Training { get; set; }
    }
}
