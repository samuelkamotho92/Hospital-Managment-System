using Hospital_Managment_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Services
{
    public class PatientService : IPatient
    {
        HospitalDBContext hospitalDBContext = new HospitalDBContext();
        public int userInput() {
            Console.WriteLine("Enter The Patient Id You want To View");
            string userInpt = Console.ReadLine();
            int num;
            bool stateInput = int.TryParse(userInpt, out num);
            if (stateInput)
            {
                List<Patient> patients = hospitalDBContext.patients.ToList();
                if (num <= patients.Count)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Patient with Id does not exist yet");
                    userInput();
                }
            }
            else
            {
                Console.WriteLine("Enter a number please");
            }
            return num;
        }

        

    public async Task AddPatient()
        {
            try
            {
                Console.WriteLine("PATIENT REGISTRATION");

                Console.WriteLine("Enter FirstName");
                string FirstName = Console.ReadLine();
                Console.WriteLine("Enter LastName");
                string LastName = Console.ReadLine();
                Console.WriteLine("Enter Email");
                string Email = Console.ReadLine();
               // Console.WriteLine("Assign to Room");
               // int Roomid = int.Parse(Console.ReadLine());
                Patient patient1 = new Patient()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                };


                hospitalDBContext.patients.Add(patient1);
                hospitalDBContext.SaveChanges();

                /* hospitalDBContext.patients.Add(patient);
                 Console.WriteLine(patient);
                 hospitalDBContext.SaveChanges();
                 Console.WriteLine("Patient Created Successfully");*/
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
           
        }

        public async Task DeletePatient()
        {
            int stdId = userInput();
            var patient = hospitalDBContext.patients.Find(stdId);
            hospitalDBContext.patients.Remove(patient);
            hospitalDBContext.SaveChanges();
            Console.WriteLine("Patient deleted Successfully");
        }

        public async Task<Patient> GetPatientById()
        {
            int stdId = userInput();
            Patient patient = hospitalDBContext.patients.Find(stdId);
            Console.WriteLine($"You selected");
            Console.WriteLine($"{patient.PatientId}:{patient.FirstName} {patient.LastName}");
            return patient;
        }

        public async Task<List<Patient>> GetPatients()
        {
            List<Patient> patients = hospitalDBContext.patients.ToList();
            Console.WriteLine("The Registered Students are");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.PatientId}: {patient.FirstName} {patient.LastName}");
            }

            return patients;
        }

        public async Task UpdatePatient()
        {
            int stdId = userInput();
            Patient patient = hospitalDBContext.patients.Find(stdId);
            Console.WriteLine(patient);
            if (patient != null)
            {
                patient.FirstName = "Samuel";
                patient.LastName = "Kamotho";
                patient.Email = "samuelkamotho92@gmail.com";
                hospitalDBContext.SaveChanges();
            }    
        }
    }
}
