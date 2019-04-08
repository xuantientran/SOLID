using MVC.Controller;
using MVC.Model;
using MVC.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC
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
			//On crée un formulaire normal mais on imprémente un interface IUsersView pour ajouter des fonctionalités
			UsersView view = new UsersView();
			view.Visible = false;

			IList users = GetUsers();

			//Le contrôleur a besoin la vue et le modèle pour fonctionner
			UsersController controller = new UsersController(view, users);

			//controller.LoadView();
			view.LoadView();
			view.ShowDialog();

		}

		/// <summary>
		/// On obtient des données du modèle
		/// </summary>
		/// <returns></returns>
		static IList GetUsers()
		{
			// Add some dummy data
			IList users = new ArrayList();
			users.Add(new User("Vladimir", "Putin", "122", "Government of Russia", User.SexOfPerson.Male));
			users.Add(new User("Barack", "Obama", "123", "Government of USA", User.SexOfPerson.Male));
			users.Add(new User("Stephen", "Harper", "124", "Government of Canada", User.SexOfPerson.Male));
			users.Add(new User("Jean", "Charest", "125", "Government of Quebec", User.SexOfPerson.Male));
			users.Add(new User("David", "Cameron", "126", "Government of United Kingdom", User.SexOfPerson.Male));
			users.Add(new User("Angela", "Merkel", "127", "Government of Germany", User.SexOfPerson.Female));
			users.Add(new User("Nikolas", "Sarkozy", "128", "Government of France", User.SexOfPerson.Male));
			users.Add(new User("Silvio", "Berlusconi", "129", "Government of Italy", User.SexOfPerson.Male));
			users.Add(new User("Yoshihiko", "Noda", "130", "Government of Japan", User.SexOfPerson.Male));
			return users;
		}
	}
}
