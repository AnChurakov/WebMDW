using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileMDW
{
	public class ProjectListPage : ContentPage
	{
		public ProjectListPage ()
		{
            Title = "Список проектов";

			Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" }
				}
			};
		}
	}
}