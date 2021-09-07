using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManagementDatabase
{
    public partial class frmUser : Form
    {

    
        public frmUser()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usermanagementDataSet.tblUserManagement' table. You can move, or remove it, as needed.
            this.tblUserManagementTableAdapter.Fill(this.usermanagementDataSet.tblUserManagement);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                tblUserManagementBindingSource.EndEdit();

                MessageBox.Show($"You have succesfully updated user details. ");
            }
            catch
            {
                MessageBox.Show("Could not update your details");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tblUserManagementBindingSource.AddNew(); //All fields will be cleared              
                checkBoxAdministrator.CheckState = CheckState.Unchecked; // Set the available check box as unchecked
                
            }
            catch
            {
                MessageBox.Show("Could not add the record to the database.");
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (tblUserManagementBindingSource.Count > 0)
            {
                tblUserManagementBindingSource.RemoveCurrent();
                
            }
            else
            {
                MessageBox.Show("We could not find a record to delete.");
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            tblUserManagementBindingSource.CancelEdit(); //cancels any changes that you have temporaraly made
            usermanagementDataSet.RejectChanges(); // Removes all changes made to the form
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Exits application 
        }
    }
}
