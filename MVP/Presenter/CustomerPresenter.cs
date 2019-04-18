using MVP.Model;
using MVP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presenter
{
	public class CustomerPresenter
	{
		private readonly ICustomerView _view;
		private readonly ICustomerRepository _repository;

		public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
		{
			_view = view;
			view.Presenter = this;
			_repository = repository;

			UpdateCustomerListView();
		}

		/// <summary>
		/// Obtient les données du Modèle
		/// Alimente la Vue des données récupérées
		/// </summary>
		private void UpdateCustomerListView()
		{
			IEnumerable<string> customerNames = from customer in _repository.GetAllCustomers() select customer.Name;
			int selectedCustomer = _view.SelectedCustomer >= 0 ? _view.SelectedCustomer : 0;
			_view.CustomerList = customerNames.ToList();
			_view.SelectedCustomer = selectedCustomer;
		}

		/// <summary>
		/// Déclenché par un évènement de la Vue, le Présenteur récupère les données depuis le Modèle et puis met à jours la Vue
		/// </summary>
		/// <param name="p"></param>
		public void UpdateCustomerView(int p)
		{
			// customer list can be cached instead of re-fetching the customer each time
			// this may be infeasible if the list is large
			Customer customer = _repository.GetCustomer(p);
			_view.CustomerName = customer.Name;
			_view.Address = customer.Address;
			_view.Phone = customer.Phone;
		}

		public void SaveCustomer()
		{
			Customer customer = new Customer { Name = _view.CustomerName, Address = _view.Address, Phone = _view.Phone };
			_repository.SaveCustomer(_view.SelectedCustomer, customer);
			UpdateCustomerListView();
		}
	}
}

