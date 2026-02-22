using Microsoft.EntityFrameworkCore;
using Npgsql;
using SaaS.NET.Infrastructure.Persistence;

namespace SaaS.NET.Web.Extensions;

public static class ApplicationExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        #region Database

        var connectionString = new NpgsqlConnectionStringBuilder
        {
            Host = builder.Configuration.GetValue<string>("Postgres:Host"),
            Port = builder.Configuration.GetValue<int>("Postgres:Port"),
            Username = builder.Configuration.GetValue<string>("Postgres:Username"),
            Password = builder.Configuration.GetValue<string>("Postgres:Password"),
            Database = builder.Configuration.GetValue<string>("Postgres:Database"),
            SslMode = SslMode.Disable
        }.ConnectionString;

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(dataSource).UseSnakeCaseNamingConvention());

        #endregion
    }
}