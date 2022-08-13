using Client.Domain.Services;
using Client.Pages.Randomizer.Card;
using Client.Pages.Randomizer.Form;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        private NameForm _nameForm;

        private ElementReference _audioElement;

        [Inject]
        private IRandomizerNameViewModel _viewModel { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private async Task AddName()
        {
            if (string.IsNullOrEmpty(_randomizee.Name))
            {
                return;
            }

            _randomizee.Id = Guid.NewGuid();

            _viewModel.AddRandomize(_randomizee);

            _randomizee = new Randomizee();


            await _nameForm.FocusAsync();

        }

        private void DeleteName(Guid id)
        {
            _viewModel.DeleteName(id);
        }

        private async Task PickRandomName()
        {
            var randomizee = _viewModel.GetRandomizee();

            _selectedRandomizee = randomizee;

            _randomNameCard.RunAnimation();

            await PlaySound();
        }

        private async Task PlaySound()
        {
            await JSRuntime.InvokeVoidAsync("playMedia", _audioElement);
        }
    }
}
