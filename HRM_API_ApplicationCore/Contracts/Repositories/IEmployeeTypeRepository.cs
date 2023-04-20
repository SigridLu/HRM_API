using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RHRM_API_ApplicationCore.Entities;

namespace HRM_API_ApplicationCore.Contracts.Repositories
{
    public interface IEmployeeTypeRepository : IBaseRepository<EmployeeType>
    {
        Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName);
    }
}
