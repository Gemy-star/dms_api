using System.Collections.Generic;
using Dms.Core.Models;

namespace Dms.Core.IRepository
{
    public interface IPatientStatusRepository:IGenericRepository<PatientStatus>
    {
        IEnumerable<PatientStatus> GetStatuses();

    }
}