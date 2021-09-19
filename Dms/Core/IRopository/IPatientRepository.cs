using System.Collections.Generic;
using System.Linq;
using Dms.Core.Models;

namespace Dms.Core.IRepository
{
    public interface IPatientRepository:IGenericRepository<Patient>
    {
        IEnumerable<Patient> GetPatients();
        //IEnumerable<Patient> GetPatientByToken(string searchTerm = null);
        Patient GetPatient(int id);
        //IQueryable<Patient> GetPatientQuery(string query);
        void Add(Patient patient);
        void Remove(Patient patient);
    }
}
