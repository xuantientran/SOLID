using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
	/// <summary>
	/// A command whose sole purpose is to relay its functionality to other
	/// objects by invoking delegates. The default return value for the CanExecute
	/// method is 'true'.
	/// </summary>
	public class RelayCommand : ICommand
	{
		#region private fields
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;
		#endregion

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested += value;
			}
			remove
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the RelayCommand class
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		public RelayCommand(Action execute)
				: this(execute, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the RelayCommand class
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		/// <param name="canExecute">The execution status logic.</param>
		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			_execute = execute;
			_canExecute = canExecute;
		}

		public void Execute(object parameter) => _execute();

		public bool CanExecute(object parameter) =>
			_canExecute == null ? true : _canExecute();
	}
}
