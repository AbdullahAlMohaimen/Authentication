using Authentication.BO;
using Authentication.HardPasswordSetup;
using Authentication.Role;
using Authentication.Service;
using Authentication.Users;
using Guna.UI2.WinForms;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Authentication.Home
{
	public partial class HardPasswordController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		DataTable allRoleDataTable = new DataTable();
		UserService userService = new UserService();
		HardPasswordSetupService hpService = new HardPasswordSetupService();
		List<BO.Users> userList = new List<BO.Users>();
		List<BO.HardPasswordSetup> allHardPasswordSetup = new List<BO.HardPasswordSetup>();
		#endregion

		#region Load
		public HardPasswordController()
		{
			InitializeComponent();
			this.loadGrid();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region AddNewRolwButton
		private void AddNewHardPassword_Click(object sender, EventArgs e)
		{
			HardPasswordSetup.HardPasswordSetup hardPasswordSetup = new HardPasswordSetup.HardPasswordSetup(this);
			hardPasswordSetup.SetCurrentUser(this.oCurrentUser);
			hardPasswordSetup.EditHardPassword(null);
			hardPasswordSetup._loginID = oCurrentUser.LoginID;
			hardPasswordSetup.EditingDone += HardPasswordEntry_EditingDone;
			hardPasswordSetup.Show();
		}
		#endregion

		#region LoadGrid
		public void loadGrid()
		{
			this.GetAllHardPassword();
		}
		#endregion

		#region Get All HardPassword
		public void GetAllHardPassword()
		{
			try
			{
				allHardPasswordSetup = new List<BO.HardPasswordSetup>();
				allHardPasswordSetup = hpService.GetHardPasswordSetups();

				if (allHardPasswordSetup.Count != 0)
				{
					this.ProcessData();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Process Role Data
		public void ProcessData()
		{
			try
			{
				total.Text = allHardPasswordSetup.Count().ToString();

				DataRow dr = null;
				DataTable hpList = new DataTable();
				hpList.TableName = "Hard Password Policy List";
				hpList.Columns.Add("ID", typeof(int));
				hpList.Columns.Add("Policy No", typeof(string));
				hpList.Columns.Add("Max. Length", typeof(int));
				hpList.Columns.Add("Min. Length", typeof(int));
				hpList.Columns.Add("Pass. Min. Age", typeof(int));
				hpList.Columns.Add("Pass Exp. Days", typeof(int));

				allHardPasswordListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				allHardPasswordListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

				foreach (BO.HardPasswordSetup oHP in allHardPasswordSetup)
				{
					dr = hpList.NewRow();
					dr["ID"] = oHP.ID;
					dr["Policy No"] = oHP.PolicyNo;
					dr["Max. Length"] = oHP.PassMaxLength;
					dr["Min. Length"] = oHP.PassMinLength;
					dr["Pass. Min. Age"] = oHP.PasswordMinimumAge;
					dr["Pass Exp. Days"] = oHP.PasswordExpDays;

					hpList.Rows.Add(dr);
				}
				allHardPasswordListTable.DataSource = hpList;
				allHardPasswordListTable.RowHeadersVisible = false;
				allHardPasswordListTable.Columns["ID"].Visible = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Search
		private void txt_HardPasswordSearch_TextChanged(object sender, EventArgs e)
		{
			allHardPasswordSetup = new List<BO.HardPasswordSetup>();
			if (!string.IsNullOrEmpty(txt_HardPasswordSearch.Text))
			{
				string searchText = txt_HardPasswordSearch.Text;
				allHardPasswordSetup = hpService.SearchHardPassword(searchText);

				this.ProcessData();
			}
			else
			{
				this.loadGrid();
			}
		}
		#endregion

		#region Edit Button
		private void editButton_click_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridView dataGridView = allHardPasswordListTable;
				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int hpID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());

					BO.HardPasswordSetup oHP = hpService.GetHardPasswordSetup(hpID);

					HardPasswordSetup.HardPasswordSetup hardPasswordSetup = new HardPasswordSetup.HardPasswordSetup(this);
					hardPasswordSetup.SetCurrentUser(this.oCurrentUser);
					hardPasswordSetup.EditHardPassword(oHP);
					hardPasswordSetup._loginID = oCurrentUser.LoginID;
					hardPasswordSetup.EditingDone += HardPasswordEntry_EditingDone;
					hardPasswordSetup.Show();
				}
				else
				{
					MessageBox.Show("Please select a row for Edit", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Edit Done
		private void HardPasswordEntry_EditingDone(object sender, EventArgs e)
		{
			this.loadGrid();
		}
		#endregion

		#region Delete Button
		private void deleteButton_Click_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridView dataGridView = allHardPasswordListTable;
				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int hpID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());

					BO.HardPasswordSetup selectedHP = hpService.GetHardPasswordSetup(hpID);

					DialogResult result = MessageBox.Show($"Are you sure to delete this Hard Password Policy?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						string rslt = hpService.Delete(selectedHP.ID);
						if (rslt == "Ok")
						{
							MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show("Deleted Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					return;
				}
				else
				{
					MessageBox.Show("Please select a row for edit", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
	}
}
