using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	/// <summary>
	/// The Command abstract class
	/// </summary>
	public abstract class OrderCommand
	{
		public abstract void Execute(List<MenuItem> order, MenuItem newItem);
	}

}
