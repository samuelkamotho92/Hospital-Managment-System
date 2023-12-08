using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string DoctorName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Speciality {  get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
