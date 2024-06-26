﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Infrastructure
{
    public static class ConnectionExtensions
    {
        public static void AddDBConnection(this IServiceCollection service)
        {
            IServiceCollection serviceCollection = service.AddDbContext<ApplicationDBContext>(options =>
            options.UseInMemoryDatabase("_"));
        }
    }


}
