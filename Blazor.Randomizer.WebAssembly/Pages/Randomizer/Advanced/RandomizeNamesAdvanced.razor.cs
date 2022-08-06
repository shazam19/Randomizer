using Client.Domain.Services;
using Client.Pages.Randomizer.Card;
using Microsoft.AspNetCore.Components;
using SzRandomizer.Model.Model;

namespace Client.Pages.Randomizer.Advanced
{
    public partial class RandomizeNamesAdvanced
    {
        private Randomizee _randomizee = new Randomizee
        {
            Name = "John Doe",
            Description = "Test description"
        };

        private Randomizee? _selectedRandomizee;

        private NameCard _randomNameCard;

        [Inject]
        private IRandomizerNameViewModel _viewModel { get; set; }

        private async Task AddName()
        {
            if (string.IsNullOrEmpty(_randomizee.Name))
            {
                return;
            }

            _randomizee.Id = Guid.NewGuid();

            _viewModel.AddRandomize(_randomizee);

            _randomizee = new Randomizee();
        }

        private void DeleteName(Guid id)
        {
            _viewModel.DeleteName(id);
        }

        private void PickRandomName()
        {
            var randomizee = _viewModel.GetRandomizee();

            _selectedRandomizee = randomizee;

            _randomNameCard.RunAnimation();
        }
    }
}
