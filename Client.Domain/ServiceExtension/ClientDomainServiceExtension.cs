using Client.Domain.Data;
using Client.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ClientDomainServiceExtension
    {
        public static void AddClientDomain(this IServiceCollection services)
        {
            services.AddTransient<IInMemoryData, InMemoryData>();
            services.AddTransient<IRandomizerNameViewModel, RandomizerNameViewModel>();
        }
    }
}
