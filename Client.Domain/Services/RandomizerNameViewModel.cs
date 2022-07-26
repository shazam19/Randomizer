using Client.Domain.Data;
using Randomizer.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.Services
{
    public class RandomizerNameViewModel : IRandomizerNameViewModel
    {
        private IInMemoryData _inMemoryData;
        private Random _random;

        public List<Randomizee> Randomizees { get; set; } = new List<Randomizee>();

        public RandomizerNameViewModel(IInMemoryData inMemoryData)
        {
            _inMemoryData = inMemoryData;

            _random = new Random();
        }

        public void AddName(string nameToAdd)
        {
            if (string.IsNullOrEmpty(nameToAdd))
            {
                return;
            }

            var randomizee = new Randomizee
            {
                Id = Guid.NewGuid(),
                Name = nameToAdd
            };

            Randomizees.Add(randomizee);
            
        }

        public Randomizee? GetRandomizee()
        {
            if(Randomizees == null || Randomizees.Count == 0)
            {
                return null;
            }

            var randomIndex = (int)_random.NextInt64(0, Randomizees.Count);

            return Randomizees[randomIndex];
        }
    }

    public interface IRandomizerNameViewModel
    {
        public List<Randomizee> Randomizees { get; set; }
        void AddName(string nameToAdd);
        Randomizee GetRandomizee();
    }
}
