using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        DataTable tbOrder = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new DataTable
            
            // Set a DataColumn Objects as a tbOrder Primary Key
            DataColumn[] keys = new DataColumn[1];

            // Create column FoodName
            DataColumn cl = new DataColumn("FoodName");
            DataColumn cl1 = new DataColumn("Quantity", typeof(int));
            tbOrder.Columns.Add(cl);
            tbOrder.Columns.Add(cl1);
            dataGridView1.DataSource = tbOrder;


            keys[0] = cl;
            tbOrder.PrimaryKey = keys;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button x = sender as Button;
            DataRow foundRow = tbOrder.Rows.Find(x.Text.ToString());
            
            if (foundRow != null)
            {
                foundRow.BeginEdit();
                foundRow["Quantity"] = int.Parse(foundRow["Quantity"].ToString()) + 1;
                foundRow.EndEdit();
            }
            else
            {
                DataRow r = tbOrder.NewRow();
                r["FoodName"] = x.Text.ToString();
                r["Quantity"] = 1;
                tbOrder.Rows.Add(r);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            int flag = dataGridView1.SelectedRows.Count;
            if (flag > 0)
            { 
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);   
            }
            else
                MessageBox.Show("Bạn phải chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK);
        }


        private void Bai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
           
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
