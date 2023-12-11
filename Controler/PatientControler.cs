using Hospital_Managment_System.Entities;
using Hospital_Managment_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controler
{
    public class PatientControler
    {
        PatientService patientService = new PatientService();
        public void patientDashboard()
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            options.Add(1, "Create Patient");
            options.Add(2, "Get All Patient");
            options.Add(3, "Get One Patient");
            options.Add(4, "Update Patient");
            options.Add(5, "Delete Patient");


            Console.WriteLine("Welcome to Patient Dashbaord , Choose Options");

            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key}:{option.Value}");
            }
            int userOpt = int.Parse(Console.ReadLine());
            if (userOpt == 1)
            {
                AddPatient patient = new AddPatient() { FirstName = "", LastName = "", Email = "" };
                patientService.AddPatient(patient);
            }else if (userOpt == 2)
            {
                patientService.GetPatients();
            }else if (userOpt == 3)
            {
                patientService.GetPatientById();
            }else if (userOpt == 4)
            {
                patientService.UpdatePatient();
            }else if (userOpt == 5)
            {
                patientService.DeletePatient();
            }
        }
    }
}
