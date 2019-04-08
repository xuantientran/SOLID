namespace MVVM.Model
{
	public class Person
	{

		private string _firstname;
		private string _lastname;
		private int _age;
		private Gender _gender;

		public string FirstName
		{
			get => _firstname;
			set => _firstname = value;
		}

		public string LastName
		{
			get => _lastname;
			set => _lastname = value;
		}

		public int Age
		{
			get => _age;
			set => _age = value;
		}

		public Gender Gender
		{
			get => _gender;
			set => _gender = value;
		}
	}
}
