using Microsoft.AspNetCore.Components;

namespace Client.Pages.Randomizer.Card
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

        private string BackgroundColor => GetBackgroundColor(Name);

        private string GetBackgroundColor(string name, bool isDarkTheme = false)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "#00000000";
            }

            int hash = SimpleStringHash(name);

            if (isDarkTheme)
            {
                return GetDarkThemedColor(hash);
            }

            return GetLightThemedColor(hash);
        }

        private static string GetDarkThemedColor(int hash)
        {
            int r = (Math.Abs(hash) % 128);
            int g = (Math.Abs(hash / 100) % 128);
            int b = (Math.Abs(hash / 10000) % 128);

            return $"#{r:X2}{g:X2}{b:X2}";
        }

        private static string GetLightThemedColor(int hash)
        {
            int r = (Math.Abs(hash) % 128) + 127; // Value between 127 and 255
            int g = (Math.Abs(hash / 100) % 128) + 127; // Just to vary the colors a bit more
            int b = (Math.Abs(hash / 10000) % 128) + 127; // Just to vary the colors a bit more

            return $"#{r:X2}{g:X2}{b:X2}";
        }

        public static int SimpleStringHash(string str)
        {
            int hash = 0;

            foreach (char c in str)
            {
                hash = (hash * 31) + c;
            }

            return hash;
        }


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

        private void RemoveAnimation()
        {
            _animationClass = string.Empty;
        }

        private string GetAnimationClass(NameCardAnimationType animationType)
        {
            switch (animationType)
            {
                case NameCardAnimationType.None:
                    return string.Empty;

                case NameCardAnimationType.BorderFlash:
                    return _animationClass == AnimationClass.BorderFlash ? AnimationClass.BorderFlash2 : AnimationClass.BorderFlash;

                case NameCardAnimationType.MoveUp:
                    return _animationClass == AnimationClass.BounceUp ? AnimationClass.BounceUp2 : AnimationClass.BounceUp;

                case NameCardAnimationType.Flip:
                    return AnimationClass.Flip;
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
            public const string MoveUp = "moveUpAnimation";
            public const string MoveUp2 = "moveUpAnimation2";
            public const string BounceUp = "animate__animated animate__bounceInUp";
            public const string BounceUp2 = "animate__animated animate__bounceInUp";
            public const string Flip = "animate__animated animate__flip";
        }

    }

    public enum NameCardAnimationType
    {
        None,
        BorderFlash,
        MoveUp,
        CenterAppear,
        Flip
    }

    
}
