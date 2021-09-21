using System;
using System.Collections.Generic;
using System.Linq;
using Dms.Core.Models;
using Dms.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Dms.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>,IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
     
        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.Include(p => p.Appointments).ToList();
        }

        
        public Patient GetPatient(int id)
        {
            return _context.Patients
                .SingleOrDefault(p => p.Id == id);
        }    
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }
       
        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}