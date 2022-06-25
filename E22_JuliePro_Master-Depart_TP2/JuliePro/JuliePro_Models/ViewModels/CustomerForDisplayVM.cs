using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models.ViewModels
{
    public class CustomerForDisplayVM
    {
        public CustomerForDisplayVM()
        { }
        public CustomerForDisplayVM(Customer b)
        {
            Id = b.Id;
            BirthDate = b.BirthDate;
            Email = b.Email;
            FirstName = b.FirstName;
            LastName = b.LastName;
            Photo = b.Photo;
            Trainer_Id = b.Trainer_Id;
            StartWeight = b.StartWeight;
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
