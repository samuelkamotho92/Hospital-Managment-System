using Hospital_Managment_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Services
{
    public class AppointmentService : IAppointment
    {
        HospitalDBContext hospitalDBContext = new HospitalDBContext();
        public int userInput()
        {
            Console.WriteLine("Enter The Appointment Id");
            string userInpt = Console.ReadLine();
            int num;
            bool stateInput = int.TryParse(userInpt, out num);
            if (stateInput)
            {
                List<Appointment> appointments = hospitalDBContext.Appointments.ToList();
                if (num <= appointments.Count)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Appointment with Id does not exist yet");
                    userInput();
                }
            }
            else
            {
                Console.WriteLine("Enter a number please");
            }
            return num;
        }

        public async Task<Appointment> AddAppointment()
        {
            Console.WriteLine("Create an appointment");
            Console.WriteLine("Enter Patient id");
            int patientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Doctor id");
            int DoctorId = int.Parse(Console.ReadLine());
            DateTime appDate1 = DateTime.Now;
            Console.WriteLine(appDate1);
            Console.WriteLine("Enter time scheduled");
            // Get the current time of day timestamp
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            // Create a TimeOnly instance from the TimeSpan
            TimeOnly currentTimeOnly = TimeOnly.FromTimeSpan(currentTime);
            Console.WriteLine(currentTime);
            Appointment appointment = new Appointment() { 
                PatientId = patientId,
                DoctorId = DoctorId,
                AppointmentDate = appDate1,
                AppointmentTime = currentTimeOnly
           };
            hospitalDBContext.Appointments.Add(appointment);
            hospitalDBContext.SaveChanges();
            Console.WriteLine("Successfuly created appointment");
            return appointment;
        }

        public async Task DeleteAppointment()
        {
            int appId = userInput();
            Appointment appoint = (Appointment)hospitalDBContext.Appointments.Where(x => x.AppointmentId == appId);
            Console.WriteLine(appoint.AppointmentTime);
           // hospitalDBContext.Appointments.Remove(appoint);
            //hospitalDBContext.SaveChanges();
            Console.WriteLine("Appointment deleted Successfully");
        }

        public async  Task<Appointment> GetAppointmentById()
        {
            int inpt = userInput();
            Appointment appointment = hospitalDBContext.Appointments.Find(inpt);
            Console.WriteLine($"{appointment.AppointmentId} : {appointment.AppointmentDate} :{appointment.AppointmentTime}");
            return appointment;
        }

        public async  Task<List<Appointment>> GetAppointments()
        {
List<Appointment> appointments = hospitalDBContext.Appointments.ToList();
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Your Appointment {appointment.AppointmentId} is scheduled for : {appointment.AppointmentDate}  at: {appointment.AppointmentTime}");
            }
            return appointments;
        }

        public async Task UpdateAppointment()
        {
            int input = userInput();
            Appointment appointment = (Appointment)hospitalDBContext.Appointments.Where(x=>x.AppointmentId==input);
           Console.WriteLine($"check value {appointment}");

            //check if the value does exist
            /*       TimeSpan currentTime = DateTime.Now.TimeOfDay;
                   TimeOnly currentTimeOnly = TimeOnly.FromTimeSpan(currentTime);
                   if (appointment != null)
                   {
                       appointment.AppointmentDate = DateTime.Now;
                       appointment.AppointmentTime = currentTimeOnly;
                       hospitalDBContext.SaveChanges();
                       Console.WriteLine("Successfully updated Appoinment");
                   }
                   else
                   {
                       Console.WriteLine("Appoinment does not exist");
                   }*/
        }
    }
}
