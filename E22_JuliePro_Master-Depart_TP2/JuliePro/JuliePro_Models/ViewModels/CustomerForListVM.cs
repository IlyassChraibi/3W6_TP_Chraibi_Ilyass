using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class CustomerForListVM
    {
        public CustomerForListVM()
        { }
        public CustomerForListVM(Customer a)
        {
            Id = a.Id;
            BirthDate = a.BirthDate;
            Email = a.Email;
            FirstName = a.FirstName;
            LastName = a.LastName;
            Photo = a.Photo;
            Trainer_Id = a.Trainer_Id;
            StartWeight = a.StartWeight;
        }
        public int Id { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public int Trainer_Id { get; set; }
        public double? StartWeight { get; set; }
    }
}
