using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controler
{
    public class AppointmentControler
    {
        public void AppointmentDashboard()
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            options.Add(1, "Create Appointments");
            options.Add(2, "Get All Appointments");
            options.Add(3, "Get One Appointment");
            options.Add(4, "Update Appointment");
            options.Add(4, "Delete Appointment");


            Console.WriteLine("Welcome to  Appointment Dashbaord , Choose Options");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}:{option.Value}");
            }
        }
    }
}
