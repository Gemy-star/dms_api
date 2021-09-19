using System.Collections.Generic;
using Dms.Core.Models;

namespace Dms.Core.IRepository
{
    public interface ISpecializationRepository:IGenericRepository<Specialization>
    {
        IEnumerable<Specialization> GetSpecializations();
    }
}
