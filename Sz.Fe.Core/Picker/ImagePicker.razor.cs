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
        private IList<string> _imageUrls;

        [Parameter]
        public IList<string> ImageUrls
        {
            get
            {
                return _imageUrls;
            }
            set
            {
                if(_imageUrls != null && _imageUrls.Equals(value))
                {
                    Console.WriteLine("same imageUrls; return");
                    return;
                }

                _imageUrls = value;

                //_imageDatas = new List<ImageData>();

                //foreach(var url in value)
                //{
                //    _imageDatas.Add(new ImageData(url));
                //}

                Console.WriteLine("inside imageUrls set");
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if(_imageUrls == null)
            {
                Console.WriteLine($"imageUrl null on Initialize");
                return;
            }

            Console.WriteLine("inside initialize");

            _imageDatas = new List<ImageData>();

            foreach (var url in _imageUrls)
            {
                _imageDatas.Add(new ImageData(url));
            }
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            Console.WriteLine("inside SetParameterAsync");
            return base.SetParametersAsync(parameters);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Console.WriteLine("inside parameterSet");
        }

        public string SelectedImageUrl { get; private set; }

        [Parameter]
        public EventCallback OnImageSelected { get; set; }

        private IList<ImageData> _imageDatas;

        private async Task OnImageUrlClick(ImageData imageData)
        {
            SelectedImageUrl = imageData.ImageUrl;

            foreach(var data in _imageDatas)
            {
                data.IsSelected = false;
            }

            imageData.IsSelected = true;

            //StateHasChanged();

            await OnImageSelected.InvokeAsync();

            //imageData.IsSelected = false;


            //foreach (var data in _imageDatas)
            //{
            //    Console.WriteLine($"url: {data.ImageUrl} isSelected: {data.IsSelected}");
            //    //data.IsSelected = false;
            //}
        }
    }

    internal class ImageData
    {

        public ImageData(string url)
        {
            ImageUrl = url;
        }

        public string ImageUrl { get; private set; }

        public bool IsSelected { get; set; }
    }
}
