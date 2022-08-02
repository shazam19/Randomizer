using Blazor.Randomizer.WebAssembly.Pages.Randomizer.Card;

namespace Blazor.Randomizer.WebAssembly.Pages.Randomizer.Medium
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
