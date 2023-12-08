using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controler
{
    public class RoomControler
    {
        public void roomDashboard()
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            options.Add(1, "Create Room");
            options.Add(2, "Get All Rooms");
            options.Add(3, "Get One Rooms");
            options.Add(4, "Update Room");
            options.Add(4, "Delete Room");


            Console.WriteLine("Welcome to Room Dashbaord , Choose Options");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}:{option.Value}");
            }

        }
    }
}
