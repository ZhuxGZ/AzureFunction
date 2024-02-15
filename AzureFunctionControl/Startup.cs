using System;
using AzureFunction.Context;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionControl.Startup))]

namespace AzureFunctionControl
{
	
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            { 
                builder.Services.AddDbContext<DataContext>();
            }
        }
    
}

