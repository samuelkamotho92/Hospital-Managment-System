using Hospital_Managment_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controler
{
    public class DoctorControler
    {
        DoctorService doctorService = new DoctorService();
        public void doctorDashboard()
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            options.Add(1, "Create Doctor");
            options.Add(2, "Get All Doctors");
            options.Add(3, "Get One Doctor");
            options.Add(4, "Update Doctor");
            options.Add(5, "Delete Doctor");


            Console.WriteLine("Welcome to Doctor Dashbaord , Choose Options");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}:{option.Value}");
            }
            int userOpt = int.Parse(Console.ReadLine());
            if (userOpt == 1)
            {
                doctorService.AddDoctor();
            }
            else if (userOpt == 2)
            {
                doctorService.GetDoctors();
            }
            else if (userOpt == 3)
            {
                doctorService.GetDoctorById();
            }
            else if (userOpt == 4)
            {
                doctorService.UpdateDoctor();
            }
            else if (userOpt == 5)
            {
                doctorService.DeleteDoctor();
            }
        }
    }
}
