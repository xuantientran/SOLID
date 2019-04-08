using MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVM.ViewModel
{
	public class MasterViewModel : ViewModelBase
	{
		#region fields
		private readonly Database _db;
		private readonly ObservableCollection<PersonViewModel> _persons;
		private readonly ICollectionView _collectionView;
		private ICommand _addCommand;
		private ICommand _removeCommand;
		private ICommand _previousCommand;
		private ICommand _nextCommand;
		#endregion

		public MasterViewModel(Database db)
		{
			_db = db;
			_persons = new ObservableCollection<PersonViewModel>();

			foreach (Person person in _db.Persons)
				_persons.Add(new PersonViewModel(person));

			_collectionView = CollectionViewSource.GetDefaultView(_persons);

			if (_collectionView == null)
				throw new NullReferenceException("collectionView");

			_collectionView.CurrentChanged += new EventHandler(OnCollectionViewCurrentChanged);
		}

		#region properties
		public ObservableCollection<PersonViewModel> Persons => _persons;

		public PersonViewModel SelectedPerson => _collectionView.CurrentItem as PersonViewModel;

		public string SearchText
		{
			set
			{
				_collectionView.Filter = (item) =>
				{
					if (item as PersonViewModel == null)
						return false;

					PersonViewModel personViewModel = (PersonViewModel)item;
					if (personViewModel.FirstName.Contains(value) ||
							personViewModel.LastName.Contains(value))
						return true;

					return false;
				};

				OnPropertyChanged("SearchContainsNoMatch");
			}
		}

		public bool SearchContainsNoMatch => _collectionView.IsEmpty;

		public ICommand AddCommand
		{
			get
			{
				if (_addCommand == null)
					_addCommand = new RelayCommand(() => AddPerson(), () => CanAddPerson());

				return _addCommand;
			}
		}

		public ICommand RemoveCommand
		{
			get
			{
				if (_removeCommand == null)
					_removeCommand = new RelayCommand(() => RemovePerson(), () => CanRemovePerson());

				return _removeCommand;
			}
		}

		public ICommand PreviousCommand
		{
			get
			{
				if (_previousCommand == null)
					_previousCommand = new RelayCommand(() => GoPrevious(), () => CanGoPrevious());

				return _previousCommand;
			}
		}

		public ICommand NextCommand
		{
			get
			{
				if (_nextCommand == null)
					_nextCommand = new RelayCommand(() => GoNext(), () => CanGoNext());

				return _nextCommand;
			}
		}

		#endregion

		private bool CanAddPerson() => _persons.Count < 5;

		private void AddPerson()
		{
			Person newPerson = _db.AddPerson("firstName", "lastName", 25, Gender.Female);
			_persons.Add(new PersonViewModel(newPerson));
		}

		private bool CanRemovePerson() => SelectedPerson != null;

		private void RemovePerson()
		{
			_db.RemovePerson(SelectedPerson.Person);
			_persons.Remove(SelectedPerson);
		}

		private bool CanGoPrevious() => _collectionView.CurrentPosition >= 1;

		private void GoPrevious() => _collectionView.MoveCurrentToPrevious();

		private bool CanGoNext() => _collectionView.CurrentPosition < _persons.Count - 1;

		private void GoNext() => _collectionView.MoveCurrentToNext();

		private void OnCollectionViewCurrentChanged(object sender, EventArgs e) =>
			OnPropertyChanged("SelectedPerson");
	}
}
