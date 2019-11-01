﻿using LiteX.HealthChecks.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;

namespace UnicornStore.Configuration
{
    public static class NpgsqlExtensions
    {
        private const string DefaultHealthCheckName = "postgresql";

        public static IHealthChecksBuilder AddPostgreSql(
          this IHealthChecksBuilder builder,
          Func<IServiceProvider, string> connectionStringFactory,
          string query = "SELECT 1;",
          string name = null,
          HealthStatus? failureStatus = null,
          IEnumerable<string> tags = null)
        {
            return builder.Add(
                new HealthCheckRegistration(
                    name ?? DefaultHealthCheckName, 
                    sp => new PostgreSqlHealthCheck(connectionStringFactory(sp), query), 
                    failureStatus, 
                    tags
                )
            );
        }
    }
}
