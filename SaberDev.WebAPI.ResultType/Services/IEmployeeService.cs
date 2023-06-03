using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaberDev.WebAPI.ResultType.Model;

namespace SaberDev.WebAPI.ResultType.Services
{
    public interface IEmployeeService
    {
        public Task<Result<Employee, ValidationFailed>> Add(Employee employee);
    }
}