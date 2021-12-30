using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    class Doctor:Person
    {
        public string fees { get; set; }
        public string days { get; set; }
        public string timing { get; set; }
        public string Username { get; set; }
        public string speciality { get; set; }
        public string Pass { get; set; }

        public Doctor() : base() { }
        public Doctor(int iD, string firstname, string lastname, string gender, string tel,string fees, string days, string timing, string Username, string Pass, string speciality):base(iD, firstname, lastname, gender, tel)
        {
            this.fees = fees;
            this.days = days;
            this.timing = timing;
            this.Username = Username;
            this.Pass = Pass;
            this.speciality = speciality;
        }
    }
}
