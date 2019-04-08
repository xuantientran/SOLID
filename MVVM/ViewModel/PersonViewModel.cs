using MVVM.Model;
using System;

namespace MVVM.ViewModel
{
	public class PersonViewModel : ViewModelBase
	{

		private readonly Person _person;

		public string FirstName
		{
			get => _person.FirstName;
			set
			{
				_person.FirstName = value;
				OnPropertyChanged("FirstName");
			}
		}

		public string LastName
		{
			get => _person.LastName;
			set
			{
				_person.LastName = value;
				OnPropertyChanged("LastName");
			}
		}

		public bool IsMale
		{
			get => _person.Gender == Gender.Male;
			set
			{
				if (value)
					_person.Gender = Gender.Male;
				else
					_person.Gender = Gender.Female;

				OnPropertyChanged("IsMale");
				OnPropertyChanged("IsFemale");
			}
		}

		public bool IsFemale
		{
			get => _person.Gender == Gender.Female;
			set
			{
				if (value)
					_person.Gender = Gender.Female;
				else
					_person.Gender = Gender.Male;

				OnPropertyChanged("IsFemale");
				OnPropertyChanged("IsMale");
			}
		}

		public int Age
		{
			get => _person.Age;
			set
			{
				_person.Age = value;
				OnPropertyChanged("FirstName");
			}
		}

		public Person Person => _person;

		public PersonViewModel(Person person)
		{
			if (person == null)
				throw new NullReferenceException("person");

			_person = person;
		}
	}
}