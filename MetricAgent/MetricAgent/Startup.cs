using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MetricAgent.DAL;
using System.Data.SQLite;
using FluentMigrator.Runner;
using System;
using AutoMapper;

namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string ConnectionString = @"Data Source=metrics.db; Version=3;";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ICpuMetricRepository, CpuMetricsRepository>();
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // добавляем поддержку SQLite 
                    .AddSQLite()
                    // устанавливаем строку подключения
                    .WithGlobalConnectionString(ConnectionString)
                    // подсказываем где искать классы с миграциями
                    .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());


            //services.AddControllers();
            //ConfigureSqlLiteConnection(services);
            //services.AddSingleton<IHddMetricRepository, HddMetricRepository>();
            //services.AddSingleton<IRamMetricRepository, RamMetricRepository>();
            //services.AddSingleton<ICpuMetricRepository, CpuMetricsRepository>();
            //services.AddSingleton<INetworkMetricRepository, NetworkMetricRepository>();
        }

        //private void ConfigureSqlLiteConnection(IServiceCollection services)
        //{
        //    const string connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        //    var connection = new SQLiteConnection(connectionString);
        //    connection.Open();
        //    PrepareSchema(connection);
        //}

        //private void PrepareSchema(SQLiteConnection connection)
        //{
        //    using (var command = new SQLiteCommand(connection))
        //    {
        //        //cpu
        //        command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
        //        command.ExecuteNonQuery();


        //        command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY,
        //            value INT, time INT)";
        //        command.ExecuteNonQuery();

        //        //hdd
        //        command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
        //        command.ExecuteNonQuery();


        //        command.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARY KEY,
        //            value LONG)";
        //        command.ExecuteNonQuery();

        //        //ram
        //        command.CommandText = "DROP TABLE IF EXISTS rammetrics";
        //        command.ExecuteNonQuery();


        //        command.CommandText = @"CREATE TABLE rammetrics(id INTEGER PRIMARY KEY,
        //            value LONG)";
        //        command.ExecuteNonQuery();
        //    }
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            migrationRunner.MigrateUp();
        }
    }
}

