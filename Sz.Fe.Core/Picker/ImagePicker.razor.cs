using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sz.Fe.Core.Picker
{
    public partial class ImagePicker
    {
        [Parameter]
        public IList<string> ImageUrls { get; set; }

        public string SelectedImageUrl { get; private set; }

        [Parameter]
        public EventCallback OnImageSelected { get; set; }

        private async Task OnImageUrlClick(string imageUrl)
        {
            SelectedImageUrl = imageUrl;

            await OnImageSelected.InvokeAsync();
        }
    }
}
