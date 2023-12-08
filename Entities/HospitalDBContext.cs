using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hospital_Managment_System.Entities
{
    public class HospitalDBContext :DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the contex
            //  optionsBuilder.UseSqlServer(@"Server=DESKTOP-KE6NN2R;Database=EFCoreDB1;Trusted_Connection=True;TrustServerCertificate=True;");
            //load configuration file
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            // Step3: Get the Section to Read from the Configuration File
            var configSection = configBuilder.GetSection("ConnectionStrings");

            // Step4: Get the Configuration Values based on the Config key
            var connectionString = configSection["SQLServerConnection"] ?? null;

            //Configuring the Connection String
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Patient> patients { get; set; }


    }
}
