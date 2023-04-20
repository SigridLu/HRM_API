using Microsoft.EntityFrameworkCore;
using RHRM_API_ApplicationCore.Entities;
using HRM_API_ApplicationCore.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM_API_Infrastructure.Data;

namespace HRM_API_Infrastructure.Repositories
{
    public class EmployeeTypeRepository : BaseRepository<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(RecruitingDbContext context) : base(context)
        {
        }
        public async Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName)
        {
            return await _dbContext.EmployeeTypes.Where(x => x.TypeName == typeName.ToLower()).FirstOrDefaultAsync();
        }
    }
}
