using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slot3_CodeFirst;

namespace libData.DbSlot3
{
    public static class DbServiceExtension
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString)
        => services.AddDbContext<Context>(d => d.UseSqlServer(connectionString));
    }
}
