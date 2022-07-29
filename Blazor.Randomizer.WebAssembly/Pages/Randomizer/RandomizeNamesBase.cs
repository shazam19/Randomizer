using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Client.Domain.Services;

namespace Blazor.Randomizer.WebAssembly.Pages.Randomizer
{
    public class RandomizeNamesBase : ComponentBase
    {
        protected string nameToAdd = "";

        protected string nameClass = "";

        protected string randomName = "";

        [Inject]
        protected IRandomizerNameViewModel _viewModel { get; set; } 

        protected ElementReference nameInput;

        protected async Task AddNameSubmit(EditContext editContext)
        {
            await AddName();
        }

        protected async Task AddName()
        {
            _viewModel.AddName(nameToAdd);

            nameToAdd = "";

            await nameInput.FocusAsync();
        }

        protected void PickRandomName()
        {
            var randomizee = _viewModel.GetRandomizee();

            if(randomizee == null)
            {
                return;
            }

            nameClass = nameClass == "szBorderFlashName" ? "szBorderFlashName2" : "szBorderFlashName";

            randomName = randomizee.Name;
        }

        protected void OnNameToAddKeyDown(KeyboardEventArgs e)
        {
            if (e.Code == "KeyR" && e.AltKey)
            {
                PickRandomName();
            }

            Console.WriteLine($"key: {e.Key}; code: {e.Code}");
        }

        protected void DeleteName(Guid id)
        {
            _viewModel.DeleteName(id);
        }
    }
}