using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class TrainerForDisplayVM
    {
        public TrainerForDisplayVM()
        { }
        public TrainerForDisplayVM(Trainer b)
        {
            Id = b.Id;
            Active = b.Active;
            Biography = b.Biography;
           // Customers = (Customer)b.Customers;
            Email = b.Email;
            FirstName = b.FirstName;
            LastName = b.LastName;
            Photo = b.Photo;
            //Speciality = b.Speciality;
            Speciality_Id= b.Speciality_Id;
           // TrainerCertification = (TrainerCertification)b.TrainerCertification;
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
       // public TrainerCertification TrainerCertification { get; set; }
    }
}
