using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinContactsSampleApp
{
	public interface IUserContactsService
	{
		Task<IEnumerable<UserContact>> GetAllContacts();
	}
}
