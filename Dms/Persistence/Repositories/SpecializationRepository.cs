using Dms.Core.Models;
using Dms.Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using Dms.Persistence;

namespace Dms.Persistence.Repositories
{
    public class SpecializationRepository : GenericRepository<Specialization>,ISpecializationRepository
    {
        public readonly ApplicationDbContext Context;

        public SpecializationRepository(ApplicationDbContext context):base(context)
        {
            Context = context;
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            return Context.Specializations.ToList();
        }
    }
}