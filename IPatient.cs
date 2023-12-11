using Hospital_Managment_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Managment_System
{
    public interface IPatient
    {
        Task<List<Patient>> GetPatients();

        Task<Patient> GetPatientById();

        Task<AddPatient> AddPatient(AddPatient patient);

        Task UpdatePatient();

        Task DeletePatient();
    }
}
