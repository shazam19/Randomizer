using SzRandomizer.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.Data
{
    public class InMemoryData : IInMemoryData
    {
        public List<Randomizee> Randomizees { get; set; } = new List<Randomizee>();

        //public void Add(string name)
        //{
        //    var randomizee = new Randomizee
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = name,
        //    };

        //    Randomizees.Add(randomizee);
        //}

    }

    public interface IInMemoryData
    {
        public List<Randomizee> Randomizees { get; set; }
    }
}
