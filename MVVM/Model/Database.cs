using System.Collections.Generic;

namespace MVVM.Model
{
	public class Database
	{
		private readonly List<Person> _persons;

		private void GetPerons()
		{
			_persons.Add(new Person
			{
				FirstName = "Jeremy",
				LastName = "Alles",
				Age = 23,
				Gender = Gender.Male
			});

			_persons.Add(new Person
			{
				FirstName = "Karine",
				LastName = "Martin",
				Age = 22,
				Gender = Gender.Female
			});

			_persons.Add(new Person
			{
				FirstName = "Adam",
				LastName = "Phesa",
				Age = 38,
				Gender = Gender.Female
			});
		}

		public Database()
		{
			_persons = new List<Person>();
			GetPerons();
		}

		public List<Person> Persons => _persons;

		public Person AddPerson(string firstname, string lastname, int age, Gender gender)
		{
			Person newPerson = new Person
			{
				FirstName = firstname,
				LastName = lastname,
				Age = age,
				Gender = gender
			};

			_persons.Add(newPerson);
			return newPerson;
		}

		public void RemovePerson(Person person) => _persons.Remove(person);
	}
}