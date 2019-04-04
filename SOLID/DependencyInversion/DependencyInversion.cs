using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependencyInversion
{
	//https://exceptionnotfound.net/simply-solid-the-dependency-inversion-principle/
	/// <summary>
	/// The Dependency Inversion Principle is comprised of two rules:
	/// High-level modules should not depend on low-level modules.Both should depend on abstractions.
	/// Notification ne dépend ni de SMS ni de Email.
	/// Notification dépend de des interfaces ICollection et IMessage
	/// SMS et Email dépendent de l'interface IMessage
	/// 
	/// Abstractions should not depend on details.  Details should depend on abstractions.
	/// IMessage ne spécifie pas des détails, elle spécifie une méthode générale Send donc l'abstraction ne depend des détails.
	/// 
	/// </summary>
	public class DependencyInversion
	{
		public static void Test()
		{
			ICollection<IMessage> messages = new List<IMessage>();
			IMessage sms = new SMS("", "sms");
			IMessage email = new Email("", "", "mail");
			messages.Add(sms);
			messages.Add(email);
			Notification notification = new Notification(messages);
			notification.Send();
		}
	}
}
