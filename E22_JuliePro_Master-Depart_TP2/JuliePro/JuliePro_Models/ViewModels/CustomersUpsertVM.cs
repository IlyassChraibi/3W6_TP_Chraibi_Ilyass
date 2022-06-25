using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class CustomersUpsertVM
    {
        public CustomersUpsertVM()
        { }
        public CustomersUpsertVM(bool isCreate, string pageTitle, string pageHeading,
            List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists)
        {
            IsCreate = isCreate;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, submitButtonText);

            ListForTrainer_Id = selectLists["ListForTrainer_Id"];
        }
        public CustomersUpsertVM(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string,
            SelectList­> selectLists, Customer customer) : this(isCreate, pageTitle, pageHeading, links, submitButtonText, selectLists)
        {
            Customer = customer;
            Id = customer?.Id;
        }
        public bool IsCreate { get; set; }
        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> ListForTrainer_Id { get; set; }
    }
}
