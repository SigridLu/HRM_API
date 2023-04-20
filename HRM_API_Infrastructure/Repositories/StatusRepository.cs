using HRM_API_ApplicationCore.Contracts.Repositories;
using HRM_API_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RHRM_API_ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_API_Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(RecruitingDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Status>> GetStatusByState(string state)
        {
            var statuses = await _dbContext.Statuses.Where(s => s.State == state).Include(s => s.Submission).ToListAsync();
            return statuses;
        }

    }
}
