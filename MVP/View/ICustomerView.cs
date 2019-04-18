using System.Collections.Generic;

namespace MVP.View
{
	/// <summary>
	/// Pour fournir la Vue des méthodes appelées par le Présenteur
	/// </summary>
	public interface ICustomerView
	{
		IList<string> CustomerList { get; set; }

		int SelectedCustomer { get; set; }

		string CustomerName { get; set; }

		string Address { get; set; }

		string Phone { get; set; }

		/// <summary>
		/// La Vue a besoin une instance du Présenter pour interagir avec lui.
		/// </summary>
		Presenter.CustomerPresenter Presenter { set; }
	}
}