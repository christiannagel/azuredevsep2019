using BooksLib.Services;
using BooksWebAPI;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(MyFunctionAppUsingEFCore.Startup))]

namespace MyFunctionAppUsingEFCore
{


    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IBooksService, BooksService>();
            builder.Services.AddDbContext<BooksContext>(config =>
            {
                config.UseSqlServer(Environment.GetEnvironmentVariable("BooksConnection"));
            });
        }
    }
}
