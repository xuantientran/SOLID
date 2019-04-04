using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependencyInjection
{
	public class UserLogic
	{
		private IEmailService _emailService;

		/// <summary>
		/// Pour ConstructorInjection
		/// </summary>
		/// <param name="emailService"></param>
		public UserLogic(IEmailService emailService)
		{
			_emailService = emailService;
		}

		/// <summary>
		/// Pour SetterInjection
		/// </summary>
		public UserLogic() { }

		/// <summary>
		/// Pour SetterInjection
		/// </summary>
		public IEmailService EmailService
		{
			get => _emailService;
			set => _emailService = value;
		}

		/// <summary>
		/// Pour ConstructorInjection et SetterInjection
		/// </summary>
		/// <param name="emailAddress"></param>
		/// <param name="message"></param>
		public void Register(string emailAddress, string message)
		{
			_emailService.SendMail(emailAddress, emailAddress);
		}

		/// <summary>
		/// pour MethodInjection
		/// </summary>
		/// <param name="emailAddress"></param>
		/// <param name="message"></param>
		/// <param name="emailService"></param>
		public void Register(string emailAddress, string message, IEmailService emailService)
		{
			emailService.SendMail(emailAddress, emailAddress);
		}


	}
}
