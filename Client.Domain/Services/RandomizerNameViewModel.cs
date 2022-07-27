using Client.Domain.Data;
using Randomizer.Model.Model;

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

        public void DeleteName(Guid id)
        {
            var randomizee = Randomizees.FirstOrDefault(x => x.Id == id);

            if(randomizee == null)
            {
                return;
            }

            Randomizees.Remove(randomizee);
        }
    }

    public interface IRandomizerNameViewModel
    {
        public List<Randomizee> Randomizees { get; set; }
        void AddName(string nameToAdd);
        Randomizee? GetRandomizee();
        void DeleteName(Guid id);
    }
}
