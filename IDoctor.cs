using Hospital_Managment_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System
{
    public interface IDoctor
    {
        Task<List<Doctor>> GetDoctors();

        Task<Doctor> GetDoctorById();

        Task<Doctor> AddDoctor();

        Task UpdateDoctor();

        Task DeleteDoctor();
    }
}
