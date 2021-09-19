using Dms.Core.Models;
using Dms.Core.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Dms.Persistence.Repositories
{
    public class PatientStatusRepository : GenericRepository<PatientStatus>,IPatientStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientStatusRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<PatientStatus> GetStatuses()
        {
            return _context.PatientStatuses.ToList();
        }
    }
}