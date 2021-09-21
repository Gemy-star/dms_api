using Dms.Core.IRepository;
using Dms.Core.Models;
using Dms.IRepository;
using Dms.Persistence;
using Dms.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDoctorRepository _doctors;
        private IPatientRepository _paitents;
        private IAppointmentRepository _apointments;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        IDoctorRepository IUnitOfWork.Doctors => _doctors ??= new DoctorRepository(_context);


        IPatientRepository IUnitOfWork.Paitents => _paitents ??= new PatientRepository(_context);


       IAppointmentRepository IUnitOfWork.Apointments => _apointments ??= new AppointmentRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
