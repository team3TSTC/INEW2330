using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Team3
{
    public partial class frmManager : Form
    {
        //var to hold default sql statement
        string sqlAll;
        public static string message = "An error has occurred in the program.";

        public frmManager()
        {
            InitializeComponent();
        }

        public void populate()
        {
            try
            {
                dgvTest.RowTemplate.Height = 63;
                string query = "SELECT * FROM group3fa212330.Menu";
                ProgOps.DatabaseCommandDGV(query, dgvTest);
                dgvTest.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            frmUpdateEmployee formNewEmployee = new frmUpdateEmployee();
            formNewEmployee.ShowDialog();
        }

        private void btnEventRequests_Click(object sender, EventArgs e)
        {

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            sqlAll = "SELECT * FROM group3fa212330.Schedule";
            ProgOps.DatabaseCommandManager(sqlAll, dgvTest);
        }

        private void btnManageMenuItems_Click(object sender, EventArgs e)
        {
            frmUpdateMenuItem updateMenu = new frmUpdateMenuItem();
            updateMenu.ShowDialog();
        }

        private void btnLocationToday_Click(object sender, EventArgs e)
        {
            frmTruckLocation truckLocation = new frmTruckLocation();
            truckLocation.ShowDialog();
        }

        private void btnPaySchedule_Click(object sender, EventArgs e)
        {
            frmPayroll payroll = new frmPayroll();
            payroll.ShowDialog();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms["frmMain"].Show();
            frmMain f2 = (frmMain)Application.OpenForms["frmMain"];
            f2.frmMain_Load(f2, EventArgs.Empty);
        }

        private void btnSeeMenuItems_Click(object sender, EventArgs e)
        {
            sqlAll = "SELECT * FROM group3fa212330.Menu";
            ProgOps.DatabaseCommandManager(sqlAll, dgvTest);
            try
            {
                populate();
                for (int i = 0; i < dgvTest.Columns.Count; i++)
                    if (dgvTest.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgvTest.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }

                dgvTest.Columns[0].Width = 100;
                dgvTest.Columns[1].Width = 100;
                dgvTest.Columns[2].Width = 150;
                dgvTest.Columns[3].Width = 350;
                dgvTest.Columns[4].Width = 100;
                dgvTest.Columns[5].Width = 125;
                dgvTest.CurrentCell = null;
                dgvTest.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(message + ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            sqlAll = "SELECT * FROM group3fa212330.Employees";
            ProgOps.DatabaseCommandManager(sqlAll, dgvTest);
        }
    }
}
