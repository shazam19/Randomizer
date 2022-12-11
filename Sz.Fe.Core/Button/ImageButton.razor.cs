using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sz.Fe.Core.Button
{
    public partial class ImageButton
    {
        [Parameter]
        public string? ImageSource { get; set; }

        //[Parameter]
        //public string? AltText { get; set; }

        [Parameter]
        public string ButtonText { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> CapturedAttributes { get; set; } = new Dictionary<string, object>
        {
            { "class", "btn btn-close" }
        };

        [Parameter]
        [Required]
        public EventCallback OnButtonClick { get; set; }

        private async Task ButtonClicked()
        {
            //if(OnButtonClick is null)
            //{
            //    throw NullReferenceException($"{nameof(OnButtonClick)} cannot be null");
            //}

            await OnButtonClick.InvokeAsync();
        }
    }
}
