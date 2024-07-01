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
    public partial class EditForm : Form
    {
        DatabaseManager dbManager = new DatabaseManager();
        private int recordId;

        public EditForm(int id)
        {
            InitializeComponent();
            recordId = id;
            LoadRecord();
        }

        private void LoadRecord()
        {
            DataTable dt = dbManager.GetAllRecords();
            DataRow row = dt.Select("ID = " + recordId)[0];

            txtType.Text = row["Type"].ToString();
            txtBrand.Text = row["Brand"].ToString();
            txtManufacturer.Text = row["Manufacturer"].ToString();
            dtpExpiryDate.Value = Convert.ToDateTime(row["ExpiryDate"]);
            txtSupplier.Text = row["Supplier"].ToString();
            nudPrice.Value = Convert.ToDecimal(row["Price"]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string type = txtType.Text;
            string brand = txtBrand.Text;
            string manufacturer = txtManufacturer.Text;
            DateTime expiryDate = dtpExpiryDate.Value;
            string supplier = txtSupplier.Text;
            decimal price = nudPrice.Value;

            dbManager.UpdateRecord(recordId, type, brand, manufacturer, expiryDate, supplier, price);
            this.Close();
        }

    }
}
