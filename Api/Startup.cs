using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Api.Data;
using System;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(Api.StartUp))]

namespace Api
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:SqlConnection");
            builder.Services.AddDbContext<SWVBADbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
}
