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

        [Parameter]
        public string ImageUrl { get; set; }
    }
}
