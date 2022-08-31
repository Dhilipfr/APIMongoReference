using Laundry.Core.DataAccess.Contracts;
using Laundry.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Laundry.Business.Employee
{
    public class EmployeeBS : IEmployeeBS
    {
        private readonly IMongoRepository<EmployeeEntity> _employeeRepository;
        public EmployeeBS(IMongoRepository<EmployeeEntity> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeEntity> GetAllEmployee()
        {            
            var employeeInfo = await _employeeRepository.FindByIdAsync("630ebb1bc358ce6536c89e5a");
            //var person = new EmployeeEntity()
            //{
            //    EmployeeName = "Dhilip"
            //};
            //await _employeeRepository.InsertOneAsync(person);
            return employeeInfo;
        }
    }
}
