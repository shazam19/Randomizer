using Client.Pages.Randomizer.Card;

namespace Client.Pages.Randomizer.Medium
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
