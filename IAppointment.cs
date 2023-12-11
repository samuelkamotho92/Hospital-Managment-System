using Hospital_Managment_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System
{
    public interface IAppointment
    {
        Task<List<Appointment>> GetAppointments();

        Task<Appointment> GetAppointmentById();

        Task<Appointment> AddAppointment();

        Task UpdateAppointment();

        Task DeleteAppointment();
    }
}
