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
        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.Include(p => p.Appointments).ToList();
        }

        /// <summary>
        /// /Get single patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patient GetPatient(int id)
        {
            return _context.Patients
                .SingleOrDefault(p => p.Id == id);
            //return _context.Patients.Find(id);
        }
        /// <summary>
        /// Get newly added patients
        /// </summary>
        /// <returns></returns>
     



        /// <summary>
        /// Add new patient
        /// </summary>
        /// <param name="patient"></param>
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }
        /// <summary>
        /// Delete existing patient
        /// </summary>
        /// <param name="patient"></param>
        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}