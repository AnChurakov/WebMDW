using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileMDW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
            Title = "Page1";
			InitializeComponent ();
		}

        private async void BackBtn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}