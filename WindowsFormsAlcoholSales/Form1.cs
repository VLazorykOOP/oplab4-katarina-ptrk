using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAlcoholSales
{
    public partial class Form1 : Form
    {
        DatabaseManager dbManager = new DatabaseManager();

        public Form1()
        {
            InitializeComponent();
            LoadRecords();
        }

        private void LoadRecords()
        {
            dataGridView1.DataSource = dbManager.GetAllRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
            LoadRecords();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                EditForm editForm = new EditForm(id);
                editForm.ShowDialog();
                LoadRecords();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                dbManager.DeleteRecord(id);
                LoadRecords();
            }
        }


    }
}
