using Dms.Core.IRepository;
using Dms.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
       IDoctorRepository Doctors { get; }
       IPatientRepository Paitents { get; }
        IPatientStatusRepository paitentstatus { get; }
        ISpecializationRepository Specialization { get; }

        IAppointmentRepository Apointments { get; }

        Task Save();
    }
}