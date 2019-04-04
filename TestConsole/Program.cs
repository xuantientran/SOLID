using Command;
using SOLID.DependencyInversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleTest
{
	class Program
	{
		static void Main(string[] args)
		{
			//TestCommand.Test();
			DependencyInversion.Test();
			Console.ReadKey();
		}
	}
}
