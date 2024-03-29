using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface ITrainersService : IBaseService
    {
        Task<GenericControllerIndexVM<TrainerForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<TrainerForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Trainer>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Trainer> GetUpsertVM(ControllerAction action, Trainer trainer);
        Task<IEnumerable<Trainer>> GetAllActive();
    }
}