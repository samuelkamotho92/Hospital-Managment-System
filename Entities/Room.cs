using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Entities
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string RoomName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string RoomType { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }  

    }
}
