using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using SaberDev.WebAPI.ResultType.Model;

namespace SaberDev.WebAPI.ResultType.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<Result<Employee, ValidationFailed>> Add(Employee employee)
        {
            if (employee.Id is null)
                return new ValidationFailed(new ValidationFailure(nameof(employee.Id), "Id not provided"));

            return new Employee() { Id = Guid.NewGuid(), Name = "Saber", LastName = "Amani" };
        }
    }
}