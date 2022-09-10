using Randomizer.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.Repository.Avatar
{
    public class AvatarInMemoryRepository : IAvatarRepository
    {
        private readonly Dictionary<string, string> _avatars = new Dictionary<string, string>()
        {
            { "1", "/Resources/Images/Avatars/user-01.png" },
            { "2", "/Resources/Images/Avatars/user-02.png" },
            { "3", "/Resources/Images/Avatars/user-03.png" },
            { "4", "/Resources/Images/Avatars/user-04.png" },
            { "5", "/Resources/Images/Avatars/user-05.png" },
            { "6", "/Resources/Images/Avatars/user-06.png" },
            { "7", "/Resources/Images/Avatars/user-07.png" },
            { "8", "/Resources/Images/Avatars/user-08.png" }
        };

        public IList<string> GetAllAvatarUrls()
        {
            return _avatars.Values.ToList();
        }

        public string GetAvatarUrl(string avatarId)
        {
            return _avatars[avatarId];
        }
    }
}
