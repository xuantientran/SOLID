using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependencyInversion
{
	public class Email : IMessage
	{
		public Email(string toAddress, string subject, string content)
		{
			ToAddress = toAddress;
			Subject = subject;
			Content = content;
		}

		public string ToAddress { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public void SendMessage()
		{
			Console.WriteLine(Content);
		}
	}
}
