using Authentication.BO;
using Authentication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Home
{
	public partial class Home : Form
	{
		#region Variable
		BO.Users oUser = new BO.Users();
		UserService _userService = new UserService();
		#endregion

		#region Constructor
		public Home()
		{
			InitializeComponent();
			//AdministratorDropDown.DataSource = Enum.GetValues(typeof(EnumAdministrator));
			this.getAllMenu();
			this.getHomeDropDownValue();
			AdministartorDashboard administartorDashboard = new AdministartorDashboard();
			AddControl(administartorDashboard);
			this.headerTitle.Text = "Dashboard";
			menuTreeView.AfterSelect += menuTreeView_AfterSelect;
		}
		#endregion

		#region Get Dropdown Data
		public void getHomeDropDownValue()
		{
			if(oUser.UserName != null)
			{
				string[] nameParts = oUser.UserName.Split(' ');
				string lastName = nameParts[nameParts.Length - 1]+"("+oUser.LoginID+")";
				homeDropDown.Items.Add(lastName);
				homeDropDown.Items.Add(oUser.UserName);
			}
			homeDropDown.Items.Add("Setting");
			homeDropDown.Items.Add("Logout");
			homeDropDown.SelectedIndex = 0;
		}
		#endregion

		#region Exit Button
		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Minimize Button
		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		#region TreeView Click
		private void menuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			OpenUserListWindow(e.Node.Text);
		}
		#endregion

		#region Get All Menu
		public void getAllMenu()
		{
			menuTreeView.Nodes.Add("Home");
			menuTreeView.Nodes.Add("Profile");
			menuTreeView.Nodes.Add("Administration");



			TreeNode administrationNode = menuTreeView.Nodes[2];
			TreeNode userNode = administrationNode.Nodes["User"];
			userNode = administrationNode.Nodes.Add("User");
			userNode.Nodes.Add("User List");

			TreeNode employeeNode = administrationNode.Nodes["Employee"];
			employeeNode = administrationNode.Nodes.Add("Employee");
			employeeNode.Nodes.Add("Employee List");
		}
		#endregion

		#region Menu wiz call
		public void OpenUserListWindow(string node)
		{
			string nodeName = node;
			this.headerTitle.Text = nodeName;
			switch (nodeName)
			{
				case "Home":
					AdministartorDashboard administartorDashboard = new AdministartorDashboard();
					AddControl(administartorDashboard);
					break;
				case "Profile":
					ProfileController profileController = new ProfileController();
					AddControl(profileController);
					break;
				case "User List":
					UserListController userListController = new UserListController();
					AddControl(userListController);
					break;
				case "Employee List":
					EmployeeListController employeeListController = new EmployeeListController();
					AddControl(employeeListController);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Add Control
		public void AddControl(UserControl controller)
		{
			controller.Dock = DockStyle.Fill;
			panelContainer.Controls.Clear();
			panelContainer.Controls.Add(controller);
			controller.BringToFront();
		}
		#endregion

		private void homeDropDown_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			string selectedValue = cmb.SelectedItem as string;

			if (selectedValue == oUser.UserName)
			{

			}

			if (selectedValue == "Setting")
			{

			}

			if (selectedValue == "Logout")
			{
		
			}
		}
	}
}
