using JuliePro_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class CustomersDisplayVM
    {
        public CustomersDisplayVM()
        { }
        public CustomersDisplayVM(bool isDetails, string pageTitle, string pageHeading,
            List<PageLinks> links, Customer customer, string submitButtonText = "")
        {
            IsDetails = isDetails;
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links,
                submitButtonText);
            Customer = new CustomerForDisplayVM(customer);
            Id = customer.Id;
        }

        public bool IsDetails { get; set; }
        public int Id { get; set; }
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
        public CustomerForDisplayVM Customer { get; set; }
    }
}
