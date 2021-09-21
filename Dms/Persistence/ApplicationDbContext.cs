using Dms.Configurations;
using Dms.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id=1,
                    Address="Cairo",
                    Name="haitham",
                    Phone="01111343463",
                    IsAvailable=true
                },
                  new Doctor
                  {
                      Id = 2,
                      Address = "Cairo",
                      Name = "Heba",
                      Phone = "01111343463",
                      IsAvailable = true
                  },
                    new Doctor
                    {
                        Id = 3,
                        Address = "Cairo",
                        Name = "Esraa",
                        Phone = "01111343463",
                        IsAvailable = true
                    }
                );

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }


    }
}
