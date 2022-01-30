using Dapper;
using MetricAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.DAL
{
    //собираемые параметры будут изменятся и добовляться
    public class RamMetricRepository : IRamMetricRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(RamMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO rammetrics(value) VALUES(@value)",
                    new
                    {
                        value = item.TotalFreeSpace
                    });
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM rammetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }

        public void Update(RamMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE rammetrics SET TotalFreeSpace = @value WHERE id=@id",
                    new
                    {
                        value = item.TotalFreeSpace,
                        id = item.Id
                    });
            }
        }

        public IList<RamMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT Id, Value FROM rammetrics").ToList();
            }
        }

        public RamMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<RamMetric>("SELECT Id, Value FROM rammetrics WHERE id=@id",
                    new { id = id });
            }
        }
    }
}
