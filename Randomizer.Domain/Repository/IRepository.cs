using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Domain.Repository
{
    public interface IRepository
    {
        T First<T>(Func<T, bool> predicate);
        T FirstOrDefault<T>(Func<T, bool> predicate);

        T SaveAsync<T>(T entity);
    }
}
