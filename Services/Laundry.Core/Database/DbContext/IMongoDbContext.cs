using Laundry.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry.Core.Database.DbContext
{
    public interface IMongoDbContext
    {
        IMongoClient DbClient { get; }
        IMongoDatabase MongoDatabase { get; }
        IMongoCollection<EmployeeEntity> EmployeeDetails { get; }
    }
}
