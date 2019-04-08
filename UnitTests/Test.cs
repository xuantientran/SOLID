using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using MVP.Model;
using MVP.Presenter;
using MVP.View;
using NUnit.Framework;

namespace UnitTest
{
	[TestFixture]
	public class Test
	{

		ICustomerView mockCustomerView;
		ICustomerRepository customerRepository;
		CustomerPresenter presenter;

		void Init()
		{
			mockCustomerView = Mock.Of<ICustomerView>();
			Mock.Get(mockCustomerView).Setup(m => m.SelectedCustomer).Returns(1);
			customerRepository = new CustomerXmlRepository(Directory.GetCurrentDirectory());
				
			presenter = new CustomerPresenter(mockCustomerView, customerRepository);
	}

		[Test]
		public void Test1()
		{
			Init();
			mockCustomerView.SelectedCustomer.Should().Be(1);
			//mockCustomerView.CustomerName.Should().Be("Jack");
		}

	}
}
