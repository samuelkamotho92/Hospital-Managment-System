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

        

    public async Task<AddPatient> AddPatient(AddPatient patient)
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
                Console.WriteLine("Assign Room");
                Console.WriteLine("Choose option");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");

                int userInp = int.Parse(Console.ReadLine());
                if (userInp == 2)
                {
                    Patient patient1 = new Patient()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Email = Email,
                        Room = new Room() { RoomNumber = "00", RoomType = "Outpatient" }
                    };

                    hospitalDBContext.patients.Add(patient1);
                    hospitalDBContext.SaveChanges();
                    Console.WriteLine("Patient Created and assigned No Room");
                }
                else if (userInp == 1)
                {
                    {
                        Console.WriteLine("Enter Room Number");
                        string roomNumber = Console.ReadLine();
                        Console.WriteLine("Enter Room Type");
                        string roomType = Console.ReadLine();
                        Patient patient1 = new Patient()
                        {
                            FirstName = FirstName,
                            LastName = LastName,
                            Email = Email,
                            Room = new Room() { RoomNumber = roomNumber, RoomType = roomType }
                        };

                        hospitalDBContext.patients.AddAsync(patient1);
                        hospitalDBContext.SaveChanges();
                        Console.WriteLine($"Patient Created and assigned to RoomNo: {roomNumber} of type {roomType}");
                    }
                }
                else
                {
                    Console.WriteLine("Choose correct option provided please");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return patient;
        }

        public async Task DeletePatient()
        {
            int stdId = userInput();
            var patient = await hospitalDBContext.patients.FindAsync(stdId);
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
            Console.WriteLine("The Registered Patients are");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.PatientId}: {patient.FirstName} {patient.LastName}");
            }

            return patients;
        }

        public async Task UpdatePatient()
        {
            Console.WriteLine("Enter Id of patient you want to update");
            int stdId = userInput();
            Patient patient = hospitalDBContext.patients.Find(stdId);
            Console.WriteLine(patient);
            if (patient != null)
            {
                patient.Email = "josee@gmail.com";
                hospitalDBContext.SaveChanges();
            }    
        }
    }
}
