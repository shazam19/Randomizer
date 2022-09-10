using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Domain.Repository
{
    public interface IAvatarRepository
    {
        IList<string> GetAllAvatarUrls();
        string GetAvatarUrl(string avatarId);
    }
}
