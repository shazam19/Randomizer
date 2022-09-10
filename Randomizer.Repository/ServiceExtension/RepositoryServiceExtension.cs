using Microsoft.Extensions.DependencyInjection;
using Randomizer.Domain.Repository;
using Randomizer.Repository.Avatar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryServiceExtension
    {
        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAvatarRepository, AvatarInMemoryRepository>();
        }
    }
}
