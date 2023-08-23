using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Randomizer.Domain.Repository;
using Sz.Fe.Core.Picker;
using SzRandomizer.Model.Model;


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

        private ImagePicker _imagePicker;

        private bool _showAvatars;

        [Inject]
        private IAvatarRepository _avatarRepository { get; set; }

        private IList<string> _avatarUrls => _avatarRepository.GetAllAvatarUrls();

        protected async Task AddNameSubmit(EditContext edit)
        {
            await AddName();
        }

        private async Task AddName()
        {
            if (string.IsNullOrEmpty(_randomizee.Name))
            {
                await _nameInput.FocusAsync();
                // show error
                return;
            }

            await OnAddNameClick.InvokeAsync();

            Console.WriteLine($"Inside AddName:focus");

            await _nameInput.FocusAsync();

            _imagePicker?.ResetSelection();
        }

        private void OnNameToAddKeyDown(KeyboardEventArgs e)
        {
            if (e.Code == "KeyR" && e.AltKey)
            {
                //PickRandomName();
            }

            Console.WriteLine($"key: {e.Key}; code: {e.Code}");
        }

        public async Task FocusAsync()
        {
            Console.WriteLine($"Inside focusAsync");

            //StateHasChanged();
            await _nameInput.FocusAsync();
        }

        private void OnImageSelected()
        {
            RandomizeeData.ImageUrl = _imagePicker.SelectedImageUrl;

            Console.WriteLine(_imagePicker.SelectedImageUrl);
        }

        private void ShowAvatars()
        {
            _showAvatars = true;
        }

        private void HideAvatars(MouseEventArgs e)
        {
            _showAvatars = false;
        }
    }
}
