using Laundry.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Laundry.Business.Employee
{
    public interface IEmployeeBS
    {
        Task<EmployeeEntity> GetAllEmployee();
    }
}
