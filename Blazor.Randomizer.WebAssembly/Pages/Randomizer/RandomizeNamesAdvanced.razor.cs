namespace Blazor.Randomizer.WebAssembly.Pages.Randomizer
{
    public partial class RandomizeNamesAdvanced
    {
        private NameCard _nameCard;

        protected override void PickRandomName()
        {
            base.PickRandomName();

            _nameCard.RunAnimation();
        }
    }
}
