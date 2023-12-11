using Hospital_Managment_System.Entities;
using Hospital_Managment_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controler
{
    public class RoomControler
    {
        RoomService roomService = new RoomService();
        public void roomDashboard()
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            options.Add(1, "Create Room");
            options.Add(2, "Get All Rooms");
            options.Add(3, "Get One Rooms");
            options.Add(4, "Update Room");
            options.Add(5, "Delete Room");


            Console.WriteLine("Welcome to Room Dashbaord , Choose Options");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}:{option.Value}");
            }

            Console.WriteLine("Choose Option");
            int userOpt = int.Parse(Console.ReadLine());

            if (userOpt == 1)
            {
                roomService.AddRoom(); 
                
            }
            else if (userOpt == 2)
            {
                roomService.GetRooms();
            }
            else if (userOpt == 3)
            {
                roomService.GetRoomById();
            }
            else if (userOpt == 4)
            {
                roomService.UpdateRoom();
            }
            else if (userOpt == 5)
            {
                roomService.DeleteRoom();
            }
        }
    }
}
