using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependencyInversion
{
	public class SMS : IMessage
	{
		public SMS(string phoneNumber, string message)
		{
			PhoneNumber = phoneNumber;
			Message = message;
		}

		public string PhoneNumber { get; set; }
		public string Message { get; set; }
		public void SendMessage()
		{
			Console.WriteLine(Message);
		}
	}
}
