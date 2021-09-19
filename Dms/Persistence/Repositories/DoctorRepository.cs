using System.Collections.Generic;
using System.Linq;
using Dms.Core.Models;
using Dms.Core.IRepository;
using Dms.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dms.Persistence.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor> ,IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Doctor> GetDectors()
        {
            return _context.Doctors
                .Include(s => s.Specialization)
                .Include(x => x.Appointments)
                .ToList();
        }

        /// <summary>
        /// Get the available doctors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Doctor> GetAvailableDoctors()
        {
            return _context.Doctors
                .Where(a => a.IsAvailable == true)
                .Include(s => s.Specialization)
                .ToList();
        }
        /// <summary>
        /// Get single Doctor - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Doctor GetDoctor(int id)
        {
            return _context.Doctors
                .Include(s => s.Specialization)
                .Include(x => x.Appointments)
                .SingleOrDefault(d => d.Id == id);
        }

        //public Doctor GetProfile(string userId)
        //{
        //    return _context.Doctors
        //        .Include(s => s.Specialization)
        //        .Include(u => u.Physician)
        //        .SingleOrDefault(d => d.PhysicianId == userId);
        //}
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }
    }
}