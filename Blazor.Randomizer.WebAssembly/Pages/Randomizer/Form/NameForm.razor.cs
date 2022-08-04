using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Randomizer.Model.Model;

namespace Client.Pages.Randomizer.Form
{
    public partial class NameForm
    {
        [Parameter]
        public EventCallback OnAddNameClick { get; set; }

        [Parameter]
        public Randomizee RandomizeeData
        {
            get
            {
                return _randomizee;
            }
            set
            {
                _randomizee = value;
            }
        }

        private Randomizee _randomizee = new Randomizee();

        private ElementReference _nameInput;

        protected async Task AddNameSubmit(EditContext editContext)
        {
            await AddName();
        }

        private async Task AddName()
        {
            if (string.IsNullOrEmpty(_randomizee.Name))
            {
                // show error
                return;
            }

            await OnAddNameClick.InvokeAsync();

            _randomizee = new Randomizee();

            await _nameInput.FocusAsync();
        }

        private void OnNameToAddKeyDown(KeyboardEventArgs e)
        {
            if (e.Code == "KeyR" && e.AltKey)
            {
                //PickRandomName();
            }

            Console.WriteLine($"key: {e.Key}; code: {e.Code}");
        }


    }
}
