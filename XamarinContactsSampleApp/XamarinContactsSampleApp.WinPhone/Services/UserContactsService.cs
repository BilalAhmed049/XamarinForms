using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinContactsSampleApp.WinPhone.Services.UserContactsService))]

namespace XamarinContactsSampleApp.WinPhone.Services
{
    public class UserContactsService : IUserContactsService
    {
        private static IList<UserContact> _contacts;

        public UserContactsService() { }

        public async Task<IEnumerable<UserContact>> GetAllContacts()
        {
            _contacts = new List<UserContact>();
            var contactStore = await ContactManager.RequestStoreAsync();
            var contacts = await contactStore.FindContactsAsync();

            foreach(Contact contact in contacts)
            {
                var userContact = new UserContact()
                {
                    ContactFirstName = contact.FirstName,
                    ContactLastName = contact.LastName,
                    ContactDisplayName = contact.DisplayName,
                    ContactPhone = contact.Phones.FirstOrDefault().Number
                };
                _contacts.Add(userContact);
            }
            return _contacts;
        }
    }
}
