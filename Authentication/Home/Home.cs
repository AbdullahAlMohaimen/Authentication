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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Authentication.Home
{
	public partial class Home : Form
	{
		#region Service
		UserService _userService = new UserService();
		#endregion

		#region Variable / Property
		BO.CurrentUser oCurrentUser = new CurrentUser();

		private Form callingForm;
		string Type;
		public string _loginID;
		public string LoginID
		{
			get { return _loginID; }
			set { _loginID = value; }
		}
		#endregion

		#region load ( Constructor ) 
		public Home(Form caller)
		{
			InitializeComponent();
			callingForm = caller;
			//AdministratorDropDown.DataSource = Enum.GetValues(typeof(EnumAdministrator));
			this.getAllMenu();
			
			AdministartorDashboard administartorDashboard = new AdministartorDashboard();
			AddControl(administartorDashboard);
			this.headerTitle.Text = "Dashboard";
			menuTreeView.AfterSelect += menuTreeView_AfterSelect;
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
			this.getHomeDropDownValue();
		}

		public void SetType(string type)
		{
			this.Type = type;
		}
		#endregion

		#region Get Dropdown Data
		public void getHomeDropDownValue()
		{
			if (oCurrentUser.UserName != null)
			{
				//string[] nameParts = oCurrentUser.UserName.Split(' ');
				//string lastName = nameParts[nameParts.Length - 1]+"("+ oCurrentUser.LoginID+")";
				//homeDropDown.Items.Add(lastName);
				homeDropDown.Items.Add(oCurrentUser.UserName);
			}
			homeDropDown.Items.Add("Change Password");
			homeDropDown.Items.Add("Setting");
			homeDropDown.Items.Add("Logout");
		}
		#endregion

		#region Exit Button
		private void Exit_Click(object sender, EventArgs e)
		{
			LoginInfo loginInfo = new LoginInfo();
			BO.Role oRole = new BO.Role();
			oRole = new RoleService().GetRoleByID(oCurrentUser.RoleID);
			loginInfo = new LoginInfoService().GetCurrentLoginInfo(oCurrentUser.LoginID, oRole.Name, System.Environment.MachineName, false);

			if (loginInfo != null)
			{
				loginInfo.LogoutTime = DateTime.Now;
				loginInfo.IsLogout = true;
				string logoutResult = new LoginInfoService().Save(loginInfo);

				if (logoutResult == "Ok")
				{
					Login.Login login = new Login.Login();
					this.Close();
					login.Close();
				}
			}
		}
		#endregion

		#region Minimize Button
		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		#region Get All Menu
		public void getAllMenu()
		{
			menuTreeView.Nodes.Add("Home");
			menuTreeView.Nodes.Add("Profile");

			menuTreeView.Nodes.Add("Administration");
			TreeNode administrationNode = menuTreeView.Nodes[2];

			TreeNode roleNode = administrationNode.Nodes["Role"];
			roleNode = administrationNode.Nodes.Add("Role");
			roleNode.Nodes.Add("Role List");

			TreeNode userNode = administrationNode.Nodes["User"];
			userNode = administrationNode.Nodes.Add("User");
			userNode.Nodes.Add("User List");
			userNode.Nodes.Add("User Information");

			TreeNode employeeNode = administrationNode.Nodes["Employee"];
			employeeNode = administrationNode.Nodes.Add("Employee");
			employeeNode.Nodes.Add("Employee List");
			employeeNode.Nodes.Add("Employee Information");

			menuTreeView.Nodes.Add("Login Information");
			TreeNode loginInformationNode = menuTreeView.Nodes[3];

			TreeNode userLoginInfoNode = loginInformationNode.Nodes.Add("User");
			userLoginInfoNode.Nodes.Add("Login Information");
			userLoginInfoNode.Nodes.Add("User Wise Login Info");
			TreeNode employeeLoginInfoNode = loginInformationNode.Nodes.Add("Employee");
			employeeLoginInfoNode.Nodes.Add("Login Information");
			employeeLoginInfoNode.Nodes.Add("Employee Wise Login Info");

			menuTreeView.Nodes.Add("Authentication");
			TreeNode authenticationNode = menuTreeView.Nodes[4];

			TreeNode passwordNode = authenticationNode.Nodes.Add("Password Management");
			passwordNode.Nodes.Add("Password Policy");
			passwordNode.Nodes.Add("Password Reset Options");
			passwordNode.Nodes.Add("Forgotten Password Recovery");

			TreeNode accessControlNode = authenticationNode.Nodes.Add("Access Control");
			accessControlNode.Nodes.Add("User Permissions");
			accessControlNode.Nodes.Add("Role Permissions");

			TreeNode accountLockoutNode = authenticationNode.Nodes.Add("Account Lockout");
			accountLockoutNode.Nodes.Add("Lockout Settings");
			accountLockoutNode.Nodes.Add("View Locked Accounts");

			TreeNode accountDeactivationNode = authenticationNode.Nodes.Add("Account Deactivation");
			accountDeactivationNode.Nodes.Add("Deactivation Settings");
			accountDeactivationNode.Nodes.Add("View Deactivated Accounts");

			// Multi-Factor Authentication (MFA)
			//TreeNode mfaNode = authenticationNode.Nodes.Add("Multi-Factor Authentication");
			//mfaNode.Nodes.Add("Enable/Disable MFA");
			//mfaNode.Nodes.Add("MFA Settings");

			// Biometric Authentication
			//TreeNode biometricNode = authenticationNode.Nodes.Add("Biometric Authentication");
			//biometricNode.Nodes.Add("Configure Biometric Options");
			//biometricNode.Nodes.Add("Biometric Settings");

			// Session Management
			//TreeNode sessionNode = authenticationNode.Nodes.Add("Session Management");
			//sessionNode.Nodes.Add("Session Timeout Settings");
			//sessionNode.Nodes.Add("Concurrent Session Control");
			//sessionNode.Nodes.Add("Session Monitoring");

			//menuTreeView.Nodes.Add("Leave");
			//TreeNode leaveNode = menuTreeView.Nodes[3];
			//TreeNode leaveYear = leaveNode.Nodes["Leave Year"];
			//leaveYear = leaveNode.Nodes.Add("Leave Year");
			//leaveYear = leaveNode.Nodes.Add("Leave Type");
			//leaveYear = leaveNode.Nodes.Add("Leave Apply");
			//leaveYear = leaveNode.Nodes.Add("Leave Approval");
		}
		#endregion

		#region TreeView Click
		private void menuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			OpenUserListWindow(e.Node.Text, Convert.ToString(e.Node.Parent));
		}
		#endregion

		#region Menu wiz call
		public void OpenUserListWindow(string node, string parent)
		{
			string nodeName = node;
			string headerName = "";
			if(nodeName == "Login Information")
			{
				if (parent == "TreeNode: User")
				{
					headerName = "User Login Information";
				}
				if (parent == "TreeNode: Employee")
				{
					headerName = "Employee Login Information";
				}
			}
			else
			{
				headerName = nodeName;
			}
			this.headerTitle.Text = headerName;
			switch (nodeName)
			{
				case "Home":
					AdministartorDashboard administartorDashboard = new AdministartorDashboard();
					administartorDashboard.SetCurrentUser(this.oCurrentUser);
					AddControl(administartorDashboard);
					break;
				case "Profile":
					ProfileController profileController = new ProfileController();
					profileController.SetCurrentUser(this.oCurrentUser);
					AddControl(profileController);
					break;
				case "Password Policy":
					HardPasswordController hardPassController = new HardPasswordController();
					hardPassController.SetCurrentUser(this.oCurrentUser);
					AddControl(hardPassController);
					break;
				case "Role List":
					RoleListController roleListController = new RoleListController();
					roleListController.SetCurrentUser(this.oCurrentUser);
					AddControl(roleListController);
					break;
				case "Login Information":
					if(parent == "TreeNode: User")
					{
						UserLoginInfoController userLoginInfoController = new UserLoginInfoController();
						userLoginInfoController.SetCurrentUser(this.oCurrentUser);
						AddControl(userLoginInfoController);
					}
					if(parent == "TreeNode: Employee")
					{

					}
					break;
				case "User Wise Login Info":
					UserWiseLoginInformation userWiseLoginInformation = new UserWiseLoginInformation();
					userWiseLoginInformation.SetCurrentUser(this.oCurrentUser);
					AddControl(userWiseLoginInformation);
					break;
				case "User List":
					UserListController userListController = new UserListController();
					userListController.SetCurrentUser(this.oCurrentUser);
					AddControl(userListController);
					break;
				case "Employee List":
					EmployeeListController employeeListController = new EmployeeListController();
					employeeListController.SetCurrentUser(this.oCurrentUser);
					AddControl(employeeListController);
					break;
				case "Employee Information":
					EmployeeInformationCOntroller employeeInformationCOntroller = new EmployeeInformationCOntroller();
					employeeInformationCOntroller.SetCurrentUser(this.oCurrentUser);
					AddControl(employeeInformationCOntroller);
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

		#region Home DropDown
		private void homeDropDown_SelectedIndexChanged(object sender, EventArgs e)
		{
            System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)sender;
			string selectedValue = cmb.SelectedItem as string;
			int selectedIndex = cmb.SelectedIndex;

			if (selectedValue == oCurrentUser.UserName && selectedIndex == 0)
			{

			}

			if (selectedValue == "Change Password" && selectedIndex == 1)
			{
				ChangePassword changePassword = new ChangePassword(this);
				changePassword._loginID = oCurrentUser.LoginID;
				changePassword.SetLoginID(oCurrentUser.LoginID);
				changePassword.SetType("Home");
				changePassword.Show();
			}

			if (selectedValue == "Setting" && selectedIndex == 2)
			{

			}

			if (selectedValue == "Logout" && selectedIndex == 3)
			{
				DialogResult result = MessageBox.Show($"Are you sure to Logout?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (result == DialogResult.OK)
				{
					this.Exit_Click(null, null);
				}
			}
		}
		#endregion

		private void btnNotification_Click(object sender, EventArgs e)
		{

		}

		private void btnApproval_Click(object sender, EventArgs e)
		{

		}

		private void btnMessage_Click(object sender, EventArgs e)
		{

		}
	}
}
