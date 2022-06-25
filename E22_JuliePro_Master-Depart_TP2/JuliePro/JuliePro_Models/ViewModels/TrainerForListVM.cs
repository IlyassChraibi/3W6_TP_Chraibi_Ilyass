using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainerForListVM
    {
        public TrainerForListVM()
        { }
        public TrainerForListVM(Trainer a)
        {
            Id = a.Id;
            Active = a.Active;
            Biography = a.Biography;
           // Customers = (Customer)a.Customers;
            Email = a.Email;
            FirstName = a.FirstName;
            LastName = a.LastName;
            Photo = a.Photo;
           // Speciality = a.Speciality;
            Speciality_Id= a.Speciality_Id;
           // TrainerCertification = (TrainerCertification)a.TrainerCertification;
        }
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Biography { get; set; }
       // public Customer Customers { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        //public Speciality Speciality { get; set; }
        public int Speciality_Id { get; set; }
       //public TrainerCertification TrainerCertification { get; set; }
    }
}