﻿using HRM_API_ApplicationCore.Contracts.Repositories;
using HRM_API_Infrastructure.Data;
using HRM_API_Infrastructure.Repositories;
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
    public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RecruitingDbContext context) : base(context)
        {
        }
        public async Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where,
            params Expression<Func<Submission, object>>[] includes)
        {
            var query = _dbContext.Set<Submission>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }
        /*
        public async Task<Submission> GetSubmissionsByJobAndCandidateIdAsync(int jobReqId, int candidateId)
        {
            return await _dbContext.Submissions.Where(x => x.JobRequirementId == jobReqId && x.CandidateId == candidateId).FirstOrDefaultAsync();
        }
        */
    }
}
