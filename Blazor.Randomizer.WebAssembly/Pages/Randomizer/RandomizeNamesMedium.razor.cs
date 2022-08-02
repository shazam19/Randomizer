namespace Blazor.Randomizer.WebAssembly.Pages.Randomizer
{
    public partial class RandomizeNamesMedium : RandomizeNamesBase
    {
        private NameCard _nameCard;

        protected override void PickRandomName()
        {
            base.PickRandomName();

            _nameCard.RunAnimation();
        }
    }
}
