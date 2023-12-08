using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public string FirstName { get; set; }    

        public string LastName { get; set; }

        public string Email { get; set; }
        public Room Room { get; set; } = new Room();

        public virtual ICollection<Appointment> Appointments { get; set; }
      }
}
