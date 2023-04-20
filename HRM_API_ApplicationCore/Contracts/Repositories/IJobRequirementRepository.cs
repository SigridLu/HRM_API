using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RHRM_API_ApplicationCore.Entities;

namespace HRM_API_ApplicationCore.Contracts.Repositories
{
    public interface IJobRequirementRepository : IBaseRepository<JobRequirement>
    {
        public Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter);
    }
}
