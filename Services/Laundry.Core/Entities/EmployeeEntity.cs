using Laundry.Core.Database;
using Laundry.Core.Entities.BaseEntities;
using Laundry.Core.Helper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry.Core.Models
{
    [BsonCollection("employeeDetails")]
    public class EmployeeEntity : Document
    {        
        public string EmployeeName { get; set; }
    }
}
