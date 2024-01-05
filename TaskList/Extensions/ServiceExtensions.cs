﻿using Contracts;
using Contracts.Interfaces;
using Entities;
using LoggerService;
using LoggerService.Services;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;

namespace TaskList.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["postgresqlConnection:connectionString"];
            services.AddDbContext<RepositoryContext>(options =>
                    options.UseNpgsql(connectionString, npgsqlOptions =>
                        npgsqlOptions.MigrationsAssembly(typeof(RepositoryContext).Assembly.FullName)));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}