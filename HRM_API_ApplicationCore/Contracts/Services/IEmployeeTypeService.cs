using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RHRM_API_ApplicationCore.Models;

namespace RHRM_API_ApplicationCore.Services
{
    public interface IEmployeeTypeService
    {
        Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> DeleteEmployeeTypeAsync(int id);
        Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypes();
        Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id);
    }
}
