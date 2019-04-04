using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependencyInjection
{
	public class GoogleEmailService : IEmailService
	{
		public void SendMail(string emailAddress, string message)
		{
			Console.WriteLine(message + " => " + emailAddress);
		}
	}
}
