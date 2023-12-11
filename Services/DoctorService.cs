using Hospital_Managment_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Services
{
    public class DoctorService : IDoctor
    {

        HospitalDBContext hospitalDBContext = new HospitalDBContext();
        public int userInput()
        {
            Console.WriteLine("Enter The Doctor Id You want To View");
            string userInpt = Console.ReadLine();
            int num;
            bool stateInput = int.TryParse(userInpt, out num);
            if (stateInput)
            {
                List<Doctor> doctors = hospitalDBContext.Doctors.ToList();
                if (num <= doctors.Count)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Doctor with Id does not exist yet");
                    userInput();
                }
            }
            else
            {
                Console.WriteLine("Enter a number please");
            }
            return num;
        }
        public async Task<Doctor> AddDoctor()
        {
            Console.WriteLine("DOCTOR REGISTRATION");

            Console.WriteLine("Enter DoctorName");
            string doctorName = Console.ReadLine();
            Console.WriteLine("Enter Speciality");
            string speciality = Console.ReadLine();

            Doctor doc1 = new Doctor()
            {
                DoctorName = doctorName,
                Speciality= speciality,
            };
            hospitalDBContext.Doctors.Add(doc1);
            hospitalDBContext.SaveChanges();
            Console.WriteLine("Doctor created successfully");
            return doc1;
        }

        public async Task DeleteDoctor()
        {
            int stdId = userInput();
            var doctor = await hospitalDBContext.Doctors.FindAsync(stdId);
            hospitalDBContext.Doctors.Remove(doctor);
            hospitalDBContext.SaveChanges();
            Console.WriteLine("Doctor deleted Successfully");
        }

        public async Task<Doctor> GetDoctorById()
        {
            int stdId = userInput();
            Doctor doctor =  hospitalDBContext.Doctors.Find(stdId);
            Console.WriteLine($"You selected Doctor");
            Console.WriteLine($"{doctor.DoctorId}:{doctor.DoctorName} {doctor.Speciality}");
            return doctor;
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            List<Doctor> doctors =  hospitalDBContext.Doctors.ToList();
            Console.WriteLine("The Registered Students are");
            foreach (var doc in doctors)
            {
                Console.WriteLine($"{doc.DoctorId}: {doc.DoctorName} {doc.Speciality}");
            }

            return doctors;
        }

        public async Task UpdateDoctor()
        {
            int stdId = userInput();
            Doctor doc = hospitalDBContext.Doctors.Find(stdId);
            Console.WriteLine(doc);
            if (doc != null)
            {
                doc.DoctorName = "Samuel";
                doc.Speciality = "Surgeon";     
                hospitalDBContext.SaveChanges();
            }

        }
    }
}
