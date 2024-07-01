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
    public partial class AddForm : Form
    {
        DatabaseManager dbManager = new DatabaseManager();

        public AddForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string type = txtType.Text;
            string brand = txtBrand.Text;
            string manufacturer = txtManufacturer.Text;
            DateTime expiryDate = dtpExpiryDate.Value;
            string supplier = txtSupplier.Text;
            decimal price = nudPrice.Value;

            dbManager.InsertRecord(type, brand, manufacturer, expiryDate, supplier, price);
            this.Close();
        }


    }
}
