﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	/// <summary>
	/// The Receiver
	/// </summary>
	public class FastFoodOrder
	{
		public List<MenuItem> currentItems { get; set; }
		public FastFoodOrder()
		{
			currentItems = new List<MenuItem>();
		}

		public void ExecuteCommand(OrderCommand command, MenuItem item)
		{
			command.Execute(this.currentItems, item);
		}

		public void ShowCurrentItems()
		{
			foreach (var item in currentItems)
			{
				item.Display();
			}
			Console.WriteLine("-----------------------");
		}

	}
}
