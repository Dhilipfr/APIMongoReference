using Laundry.Core.Models;
using Laundry.Core.Models.Application;
using MongoDB.Driver;
using MongoDB.Driver.Core.Compression;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry.Core.Database.DbContext
{
    public class MongoDbContext:IMongoDbContext
    {
		public IMongoDatabase MongoDatabase { get; }

		private static MongoClient _dbClient;

		public MongoDbContext(AppSettings appSettings)
		{
			if (string.IsNullOrEmpty(appSettings.ConnectionString))
				throw new ArgumentNullException(nameof(appSettings.ConnectionString));
			if (string.IsNullOrEmpty(appSettings.DatabaseName))
				throw new ArgumentNullException(nameof(appSettings.DatabaseName));

			var settings = MongoClientSettings.FromUrl(new MongoUrl(appSettings.ConnectionString));

			/**
			 * Uncomment below piece of code if you want to DEBUG any mongoQueries that are failing and you want the RAW Query
			 */
			// settings.ClusterConfigurator = cb =>
			// {
			// 	cb.Subscribe<CommandStartedEvent>(e => {
			// 		Debug.Write($"{e.CommandName} - {e.Command.ToJson()}");
			// 	});
			// };

			// set the max connection idle time to 60s
			settings.MaxConnectionIdleTime = TimeSpan.FromSeconds(60);

			settings.Compressors = new List<CompressorConfiguration>() {
			   new CompressorConfiguration(CompressorType.ZStandard)
			};

			_dbClient = new MongoClient(settings);			
			MongoDatabase = _dbClient.GetDatabase(appSettings.DatabaseName);
		}

		public IMongoClient DbClient => _dbClient;		

		public IMongoCollection<EmployeeEntity> EmployeeDetails => MongoDatabase.GetCollection<EmployeeEntity>(MongoCollections.EmployeeEntity);
	}
}
