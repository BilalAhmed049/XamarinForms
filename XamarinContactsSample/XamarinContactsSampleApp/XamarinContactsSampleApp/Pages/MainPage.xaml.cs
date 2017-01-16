using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamarinContactsSampleApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void ShowContacts(object sender, EventArgs e)
		{
			var contacts = await DependencyService.Get<IUserContactsService>().GetAllContacts();
			foreach (UserContact contact in contacts)
			{
				ContactsLabel.Text = ContactsLabel.Text + contact.ContactFirstName + " " + contact.ContactPhone + "\n";
			}
		}
	}
}
