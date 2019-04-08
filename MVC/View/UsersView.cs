using MVC.Controller;
using MVC.Model;
using System;
using System.Windows.Forms;


namespace MVC.View
{
	public partial class UsersView : Form, IUsersView
	{
		UsersController _controller;

		public UsersView()
		{
			InitializeComponent();
		}

		#region Events raised  back to controller

		private void btnAdd_Click(object sender, EventArgs e) =>
			_controller.AddNewUser();

		private void btnRemove_Click(object sender, EventArgs e) =>
			_controller.RemoveUser();

		private void btnRegister_Click(object sender, EventArgs e) =>
			_controller.Save();

		private void grdUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (grdUsers.SelectedItems.Count > 0)
				_controller.SelectedUserChanged(grdUsers.SelectedItems[0].Text);
		}
		#endregion

		#region ICatalogView implementation

		public void SetController(UsersController controller) =>
			_controller = controller;

		public void ClearGrid()
		{
			// Define columns in grid
			grdUsers.Columns.Clear();

			grdUsers.Columns.Add("Id", 150, HorizontalAlignment.Left);
			grdUsers.Columns.Add("First Name", 150, HorizontalAlignment.Left);
			grdUsers.Columns.Add("Lastst Name", 150, HorizontalAlignment.Left);
			grdUsers.Columns.Add("Department", 150, HorizontalAlignment.Left);
			grdUsers.Columns.Add("Sex", 50, HorizontalAlignment.Left);

			// Add rows to grid
			grdUsers.Items.Clear();
		}

		public void AddUserToGrid(User usr)
		{
			ListViewItem parent;
			parent = grdUsers.Items.Add(usr.ID);
			parent.SubItems.Add(usr.FirstName);
			parent.SubItems.Add(usr.LastName);
			parent.SubItems.Add(usr.Department);
			parent.SubItems.Add(Enum.GetName(typeof(User.SexOfPerson), usr.Sex));
		}

		public void UpdateGridWithChangedUser(User usr)
		{
			ListViewItem rowToUpdate = null;

			foreach (ListViewItem row in grdUsers.Items)
			{
				if (row.Text == usr.ID)
				{
					rowToUpdate = row;
				}
			}

			if (rowToUpdate != null)
			{
				rowToUpdate.Text = usr.ID;
				rowToUpdate.SubItems[1].Text = usr.FirstName;
				rowToUpdate.SubItems[2].Text = usr.LastName;
				rowToUpdate.SubItems[3].Text = usr.Department;
				rowToUpdate.SubItems[4].Text = Enum.GetName(typeof(User.SexOfPerson), usr.Sex);
			}
		}

		public void RemoveUserFromGrid(User usr)
		{

			ListViewItem rowToRemove = null;

			foreach (ListViewItem row in grdUsers.Items)
			{
				if (row.Text == usr.ID)
				{
					rowToRemove = row;
				}
			}

			if (rowToRemove != null)
			{
				grdUsers.Items.Remove(rowToRemove);
				grdUsers.Focus();
			}
		}

		public string GetIdOfSelectedUserInGrid()
		{
			if (grdUsers.SelectedItems.Count > 0)
				return grdUsers.SelectedItems[0].Text;
			else
				return "";
		}

		public void SetSelectedUserInGrid(User usr)
		{
			foreach (ListViewItem row in grdUsers.Items)
			{
				if (row.Text == usr.ID)
				{
					row.Selected = true;
					break;
				}
			}
		}

		public string FirstName
		{
			get { return txtFirstName.Text; }
			set { txtFirstName.Text = value; }
		}

		public string LastName
		{
			get { return txtLastName.Text; }
			set { txtLastName.Text = value; }
		}

		public string ID
		{
			get { return txtID.Text; }
			set { txtID.Text = value; }
		}

		public string Department
		{
			get { return txtDepartment.Text; }
			set { txtDepartment.Text = value; }
		}

		public User.SexOfPerson Sex
		{
			get
			{
				if (rdMale.Checked)
					return User.SexOfPerson.Male;
				else
					return User.SexOfPerson.Female;
			}
			set
			{
				if (value == User.SexOfPerson.Male)
					rdMale.Checked = true;
				else
					rdFamele.Checked = true;
			}
		}

		public bool CanModifyID
		{
			set => txtID.Enabled = value;
		}

		#endregion

		public void LoadView()
		{
			ClearGrid();
			foreach (User usr in _controller.Users)
				AddUserToGrid(usr);

			SetSelectedUserInGrid((User)_controller.Users[0]);
		}
	}
}
