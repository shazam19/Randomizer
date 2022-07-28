using Microsoft.AspNetCore.Components;

namespace Blazor.Randomizer.WebAssembly.Pages.Randomizer
{
    public partial class NameCard
    {
        [Parameter]
        public string Name { get; set; } = "Umar bin Khattab";

        [Parameter]
        public string Description { get; set; } = "Khalifatun Rashedin";

        [Parameter]
        public string ImageUrl { get; set; } = @"https://cdn2.iconfinder.com/data/icons/avatar-vol-1-5/512/7_Asian_avatar_businessman_chinese-512.png";
    }
}
