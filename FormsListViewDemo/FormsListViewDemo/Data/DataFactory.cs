using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FormsListViewDemo
{
	public class DataFactory
	{
		public static IList<Person> People { get; private set; }

		static DataFactory()
		{
			People = new ObservableCollection<Person> {
				new Person {
					Name = "Jan Kowalski",
					Thumbnail = "Jan.png",
					Email = "jan@ahotmail.com",
					IsFavorite = false,
				},

				new Person {
					Name = "Julia Kowalska",
					Thumbnail = "Julia.png",
					Email = "mjulia@hotmail.com",
					IsFavorite = true,
				},

				new Person {
					Name = "Bartosz Kowalski",
					Thumbnail = "Bartek.png",
					Email = "bartek@hotmail.com",
					IsFavorite = true,
				},

				new Person {
					Name = "Liza Kowalska",
					Thumbnail = "Liza.png",
					Email = "liza@hotmail.com",
					IsFavorite = true,
				},

				new Person {
					Name = "Marek Kowalski",
					Thumbnail = "Marek.png",
					Email = "marek@ghotmail.com",
					IsFavorite = false,
				},

				new Person {
					Name = "Adrian Kowalski",
					Thumbnail = "Adrian.png",
					Email = "adrian@hotmail.com",
					IsFavorite = false,
				},

				new Person {
					Name = "Anna Kowalska",
					Thumbnail = "Anna.jpg",
					Email = "anna@hotmail.com",
					IsFavorite = false
				}
			};
		}
	}
}
