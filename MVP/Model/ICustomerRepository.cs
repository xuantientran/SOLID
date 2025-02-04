﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Model
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAllCustomers();

		Customer GetCustomer(int id);

		void SaveCustomer(int id, Customer customer);
	}
}
