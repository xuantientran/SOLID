using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP
{
	static class Program
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Modèle
			var repository = new Model.CustomerXmlRepository(Application.StartupPath);
			//Vue
			var view = new View.CustomerForm();

			// TODO: IOC
			//Présenteur
			var presenter = new Presenter.CustomerPresenter(view, repository);
			Application.Run(view);
		}
	}
}
