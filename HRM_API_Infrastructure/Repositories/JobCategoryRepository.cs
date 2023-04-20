using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM_API_ApplicationCore.Contracts.Repositories;
using HRM_API_Infrastructure.Data;
using RHRM_API_ApplicationCore.Entities;

namespace HRM_API_Infrastructure.Repositories
{
    public class JobCategoryRepository : BaseRepository<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(RecruitingDbContext context) : base(context)
        {
        }
    }
}
