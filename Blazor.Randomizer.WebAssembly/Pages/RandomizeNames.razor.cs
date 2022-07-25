using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.Randomizer.WebAssembly.Pages
{
    public partial class RandomizeNames
    {
        private string nameToAdd = "";

        private string nameClass = "";

        private string randomName = "";

        private List<string> names = new List<string>();

        private Random random = new Random();

        private EmptyViewModel emptyViewModel { get; set; } = new EmptyViewModel();

        private ElementReference nameInput;

        private async Task AddNameSubmit(EditContext editContext)
        {
            await AddName();
        }

        private async Task AddName()
        {
            if (string.IsNullOrEmpty(nameToAdd))
            {
                return;
            }

            names.Add(nameToAdd);
            nameToAdd = "";

            await nameInput.FocusAsync();
        }

        private void PickRandomName()
        {
            nameClass = nameClass == "szBorderFlashName" ? "szBorderFlashName2" : "szBorderFlashName";

            var randomIndex = (int)random.NextInt64(0, names.Count);

            randomName = names[randomIndex];

        }

        private void OnNameToAddKeyDown(KeyboardEventArgs e)
        {
            if (e.Code == "KeyR" && e.AltKey)
            {
                PickRandomName();
            }

            Console.WriteLine($"key: {e.Key}; code: {e.Code}");
        }

        public class EmptyViewModel
        {

        }
    }
}