using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM_API_ApplicationCore.Models;
using RHRM_API_ApplicationCore.Models;

namespace RHRM_API_ApplicationCore.Services
{
    public interface IJobRequirementService
    {
        Task<int> AddJobRequirementAsync(JobRequirementRequestModel model);
        Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model);
        Task<int> DeleteJobRequirementAsync(int id);
        Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements();
        Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id);
    }
}
