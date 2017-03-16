using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormsListViewDemo
{
	public class Person : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		public string Thumbnail { get; set; }

		string name;
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

		string email;
		public string Email
		{
			get { return email; }
			set { SetProperty(ref email, value); }
		}

		bool isFavorite;
		public bool IsFavorite
		{
			get { return isFavorite; }
			set { SetProperty(ref isFavorite, value); }
		}


		bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
			if (!object.Equals(field, value))
			{
				field = value;
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
