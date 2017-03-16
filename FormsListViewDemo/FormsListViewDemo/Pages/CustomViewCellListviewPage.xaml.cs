using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsListViewDemo
{
	public partial class CustomViewCellListviewPage : ContentPage
	{
		public CustomViewCellListviewPage()
		{
			InitializeComponent();
		}

		async void OnDelete(object sender, EventArgs e)
		{
			MenuItem item = (MenuItem)sender;
			Person person = (Person)item.BindingContext;
			await DeletePersonAsync(person);
		}

		async Task DeletePersonAsync(Person person)
		{
			if (person != null)
			{
				if (await this.DisplayAlert("Confirm", "Are you sure you want to delete " + person.Name, "Yes", "No") == true)
					DataFactory.People.Remove(person);
			}
		}

		void OnRefreshing(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;

			lv.IsRefreshing = false;
		}
	}
}
