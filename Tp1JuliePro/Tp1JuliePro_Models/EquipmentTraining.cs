using Tp1JuliePro_Models;

namespace JuliePro_Models
{
    public class EquipmentTraining {

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int TrainingId { get; set; }


        public Training Training { get; set; }


    }
}
