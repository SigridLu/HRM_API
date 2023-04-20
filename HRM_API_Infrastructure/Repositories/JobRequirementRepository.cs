using HRM_API_ApplicationCore.Contracts.Repositories;
using HRM_API_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using RHRM_API_ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRM_API_Infrastructure.Repositories
{
    public class JobRequirementRepository : BaseRepository<JobRequirement>, IJobRequirementRepository
    {
        public JobRequirementRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter)
        {
            return await _dbContext.JobRequirements.Include("JobCategory").Where(filter).ToListAsync();
        }
    }
}
