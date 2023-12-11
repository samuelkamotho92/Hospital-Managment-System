using Hospital_Managment_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controler
{
    public class AppointmentControler
    {
        AppointmentService appointment = new AppointmentService();
        public void AppointmentDashboard()
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            options.Add(1, "Create Appointments");
            options.Add(2, "Get All Appointments");
            options.Add(3, "Get One Appointment");
            options.Add(4, "Update Appointment");
            options.Add(5, "Delete Appointment");


            Console.WriteLine("Welcome to  Appointment Dashbaord , Choose Options");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}:{option.Value}");
            }
            int userInp = int.Parse(Console.ReadLine());
            if (userInp == 1)
            {
                appointment.AddAppointment();
            }
            else if (userInp == 2)
            {
                appointment.GetAppointments();
            }
            else if(userInp == 3)
            {
                appointment.GetAppointmentById();
            }else if (userInp == 4)
            {
                appointment.UpdateAppointment();
            }else if(userInp == 5)
            {
                appointment.DeleteAppointment();
            }
            else
            {
                Console.WriteLine("Enter correct option provided");
            }
        }
    }
}
