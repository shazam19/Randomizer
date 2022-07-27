using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Client.Domain.Services;

namespace Blazor.Randomizer.WebAssembly.Pages.Randomizer
{
    public partial class RandomizeNames
    {
        private string nameToAdd = "";

        private string nameClass = "";

        private string randomName = "";

        [Inject]
        private IRandomizerNameViewModel _viewModel { get; set; } 

        private ElementReference nameInput;

        private async Task AddNameSubmit(EditContext editContext)
        {
            await AddName();
        }

        private async Task AddName()
        {
            _viewModel.AddName(nameToAdd);

            nameToAdd = "";

            await nameInput.FocusAsync();
        }

        private void PickRandomName()
        {
            var randomizee = _viewModel.GetRandomizee();

            if(randomizee == null)
            {
                return;
            }

            nameClass = nameClass == "szBorderFlashName" ? "szBorderFlashName2" : "szBorderFlashName";

            randomName = randomizee.Name;
        }

        private void OnNameToAddKeyDown(KeyboardEventArgs e)
        {
            if (e.Code == "KeyR" && e.AltKey)
            {
                PickRandomName();
            }

            Console.WriteLine($"key: {e.Key}; code: {e.Code}");
        }

        private void DeleteName(Guid id)
        {
            _viewModel.DeleteName(id);
        }
    }
}