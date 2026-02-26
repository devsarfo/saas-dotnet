using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SaaS.NET.Infrastructure.Persistence;
using SaaS.NET.Infrastructure.Seeders;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development"}.json",
        optional: true)
    .AddEnvironmentVariables();


var services = new ServiceCollection();

IConfiguration configuration = builder.Build();
var connectionString = new NpgsqlConnectionStringBuilder
{
    Host = configuration.GetValue<string>("Postgres:Host"),
    Port = configuration.GetValue<int>("Postgres:Port"),
    Username = configuration.GetValue<string>("Postgres:Username"),
    Password = configuration.GetValue<string>("Postgres:Password"),
    Database = configuration.GetValue<string>("Postgres:Database"),
    SslMode = SslMode.Disable
}.ConnectionString;
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
dataSourceBuilder.EnableDynamicJson();
var dataSource = dataSourceBuilder.Build();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(dataSource).UseSnakeCaseNamingConvention());

services.AddScoped<DatabaseSeeder>();

var serviceProvider = services.BuildServiceProvider();

try
{
    Console.WriteLine("Applying migrations...");

    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();
    Console.WriteLine("Database migration completed successfully...\n");

    Console.WriteLine("Seeding database...");
    var databaseSeeder = serviceProvider.GetRequiredService<DatabaseSeeder>();
    await databaseSeeder.Run();
    Console.WriteLine("Database seeding completed successfully....\n");
}
catch (Exception ex)
{
    Console.WriteLine("Error migrating database: ");
    Console.WriteLine(ex.ToString());
}