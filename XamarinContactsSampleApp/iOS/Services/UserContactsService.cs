using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinContactsSampleApp.iOS.Services.UserContactsService))]
namespace XamarinContactsSampleApp.iOS.Services
{
	public class UserContactsService : IUserContactsService
	{
		private readonly Xamarin.Contacts.AddressBook _book;

		private static IList<UserContact> _contacts;

		public UserContactsService()
		{
			_book = new Xamarin.Contacts.AddressBook();
		}

		public async Task<IEnumerable<UserContact>> GetAllContacts()
		{
			if (_contacts != null) return _contacts;

			var contacts = new List<UserContact>();
			await _book.RequestPermission().ContinueWith(t =>
			{
				if (!t.Result)
				{
					Console.WriteLine("Sorry ! Permission was denied by user or manifest !");
					return;
				}
				foreach (var contact in _book.ToList().Where(c => c.Phones.Any())) // Filtering the Contact's that has at least one number
				{
					var firstOrDefault = contact.Phones.FirstOrDefault();
					if (firstOrDefault != null)
					{
						contacts.Add(new UserContact
						{
							ContactFirstName = contact.FirstName,
							ContactLastName = contact.LastName,
							ContactDisplayName = contact.DisplayName,
							ContactPhone = firstOrDefault.Number,
						});
					}
				}
			});

			_contacts = (from c in contacts orderby c.ContactFirstName select c).ToList();
			return _contacts;
		}
	}
}
