using System.Collections.Generic;
using Dms.Core.Models;

namespace Dms.Core.IRepository
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        IEnumerable<Doctor> GetDectors();
        IEnumerable<Doctor> GetAvailableDoctors();
        Doctor GetDoctor(int id);
        //Doctor GetProfile(string userId);
        void Add(Doctor doctor);
    }
}