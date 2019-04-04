using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependencyInjection
{
	public class DependencyInjection
	{
		static string email = "user@fr.fr";
		static string message = "abc";

		public static void ConstructorInjection()
		{
			GoogleEmailService googleEmailService = new GoogleEmailService();
			UserLogic userLogic = new UserLogic(googleEmailService);
			userLogic.Register(email, message);
		}

		public static void SetterInjection()
		{
			OutlookEmailService outlookEmailService = new OutlookEmailService();
			UserLogic userLogic = new UserLogic()
			{
				EmailService = outlookEmailService
			};
			userLogic.Register(email, message);
		}

		public static void MethodInjection()
		{
			OutlookEmailService outlookEmailService = new OutlookEmailService();
			UserLogic userLogic = new UserLogic();
			userLogic.Register(email, message, outlookEmailService);
		}

	}
}
