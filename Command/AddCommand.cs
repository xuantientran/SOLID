using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	/// <summary>
	/// A concrete command
	/// </summary>
	public class AddCommand : OrderCommand
	{
		public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
		{
			currentItems.Add(newItem);
		}
	}

}
