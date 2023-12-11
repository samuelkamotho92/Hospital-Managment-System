using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Entities
{
    public class AddRoom
    {
        public int RoomId { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string RoomNumber { get; set; }
       [Column(TypeName = "varchar(50)")]
        public string RoomType { get; set; }
    }
}
