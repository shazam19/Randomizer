using Microsoft.AspNetCore.Components;

namespace Blazor.Randomizer.WebAssembly.Pages.Randomizer
{
    public partial class NameCard
    {
        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public string? Description { get; set; } //= "Khalifatun Rashedin";

        [Parameter]
        public string? ImageUrl { get; set; } //= @"https://cdn2.iconfinder.com/data/icons/avatar-vol-1-5/512/7_Asian_avatar_businessman_chinese-512.png";

        [Parameter]
        public bool HideDelete { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? CardAttributes { get; set; }

        [Parameter]
        public NameCardAnimationType AnimationType
        {
            get => _animationType; 
            set
            {
                _animationType = value;

                Console.WriteLine($"inside animationtype: {value}");

                Console.WriteLine($"insder setter");
            }
        }

        public void RunAnimation()
        {
            _animationClass = GetAnimationClass(AnimationType);
        }

        private string GetAnimationClass(NameCardAnimationType animationType)
        {
            switch (animationType)
            {
                case NameCardAnimationType.None:
                    return string.Empty;

                case NameCardAnimationType.BorderFlash:
                    return _animationClass == AnimationClass.BorderFlash ? AnimationClass.BorderFlash2 : AnimationClass.BorderFlash;
            }

            return string.Empty;
        }

        private string? _animationClass;
        private NameCardAnimationType _animationType;

        [Parameter]
        public EventCallback OnDeleteButtonClick { get; set; }

        private async Task OnDeleteClickInternal()
        {
            if (HideDelete)
            {
                return;
            }

            await OnDeleteButtonClick.InvokeAsync();
        }

        private string GetCssClasses()
        {
            return $"container mt-3 card {_animationClass}";
        }

        private class AnimationClass
        {
            public const string BorderFlash = "borderAnimation";
            public const string BorderFlash2 = "borderAnimation2";
        }

    }

    public enum NameCardAnimationType
    {
        None,
        BorderFlash,
        MoveUp,
        CenterAppear
    }

    
}
