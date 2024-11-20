using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.Models;
using HealthCareSystem.Core.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicalRecord> medicalRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }
}