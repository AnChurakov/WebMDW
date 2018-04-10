//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//namespace MobileMDW
//{
//    [ContentProperty("Source")]
//    class ImageResourceExtension
//    {
//        public string Source { get; set; }

//        public object ProvideValue(IServiceProvider serviceProvider)
//        {
//            if (Source == null)
//            {
//                return null;
//            }
//            var imageSource = ImageSource.FromResource(Source);

//            return imageSource;
//        }
//    }
//}
