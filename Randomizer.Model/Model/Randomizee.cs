using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzRandomizer.Model.Model
{
    /// <summary>
    /// Object to hold value to randomize
    /// </summary>
    public class Randomizee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
