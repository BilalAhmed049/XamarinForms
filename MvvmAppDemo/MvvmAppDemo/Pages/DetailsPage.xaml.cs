using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MvvmAppDemo
{
	public partial class DetailsPage : ContentPage
	{
		public DetailsPage()
		{
			InitializeComponent();
			BindingContext = App.Locator.DetailsViewModel;
		}
	}
}
