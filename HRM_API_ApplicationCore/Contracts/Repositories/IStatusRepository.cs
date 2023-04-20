using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RHRM_API_ApplicationCore.Entities;

namespace HRM_API_ApplicationCore.Contracts.Repositories
{
    public interface IStatusRepository : IBaseRepository<Status>
    {
        public Task<IEnumerable<Status>> GetStatusByState(string state);
    }
}
