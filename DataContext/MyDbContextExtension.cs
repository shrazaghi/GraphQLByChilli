using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace DataContext;

public static class MyDbContextExtension
{
    public static IServiceCollection AddMyDbContext(this IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseSqlServer("Data Source=DESKTOP-BQPQRM2;Initial Catalog=AdventureWorks2019;Integrated Security=True;Encrypt=False");
            options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        });

        return services;
    }
}
