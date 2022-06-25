using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class CustomersIndexVM
    {
        public CustomersIndexVM()
        { }
        public CustomersIndexVM(string pageTitle, string pageHeading,
            List<PageLinks> links, ICollection<Customer> customers)
        {
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links);
            Customers = customers.Select(b => new CustomerForListVM(b)).ToList();
        }

        public int? Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public ICollection<CustomerForListVM> Customers { get; set; }
    }
}
