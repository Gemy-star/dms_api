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
                .Include(x => x.Appointments)
                .ToList();
        }

       
        public IEnumerable<Doctor> GetAvailableDoctors()
        {
            return _context.Doctors
                .Where(a => a.IsAvailable == true)
                .ToList();
        }
    
        public Doctor GetDoctor(int id)
        {
            return _context.Doctors
                .Include(x => x.Appointments)
                .SingleOrDefault(d => d.Id == id);
        }

        public Doctor GetProfile(int userId)
        {
            return _context.Doctors
                .SingleOrDefault(d => d.Id == userId);
        }
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }
    }
}