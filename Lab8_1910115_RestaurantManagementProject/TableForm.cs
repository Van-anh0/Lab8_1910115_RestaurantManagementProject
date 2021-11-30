using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;

namespace Lab8_1910115_RestaurantManagementProject
{
    public partial class TableForm : Form
    {

        List<Table> listTable = new List<Table>();
        Table tableCurrent = new Table();
        public TableForm()
        {
            InitializeComponent();
        }

        private void lvTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem listViewItem = new ListViewItem();
        }

        public int InsertTable()
        {
            
            Table table = new Table();
            table.ID = 0;
            
            if (txtName.Text == "" || txtStatus.Text == "" || txtCapacity.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
               
                table.Name = txtName.Text;
                table.Status = int.Parse(txtStatus.Text);
                table.Capacity = int.Parse(txtCapacity.Text);
                
                TableBL tableBL = new TableBL();
                // Chèn dữ liệu vào bảng
                return tableBL.Insert(table);
            }
            return -1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Gọi phương thức thêm dữ liệu
            int result = InsertTable();
            if (result > 0) // Nếu thêm thành công
            {
                // Thông báo kết quả
                MessageBox.Show("Thêm dữ liệu thành công");
                // Tải lại dữ liệu cho ListView
                LoadTableToLV();
            }
            // Nếu thêm không thành công thì thông báo cho người dùng
            else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        public int UpdateFood()
        {
            
            Table table = tableCurrent;
            // Kiểm tra nếu các ô nhập khác rỗng
            if (txtName.Text == "" || txtStatus.Text == "" || txtCapacity.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name, Unit, và Notes khi người dùng sửa
                table.Name = txtName.Text;
                table.Status = int.Parse(txtStatus.Text);
                table.Capacity = int.Parse(txtCapacity.Text);
                
                TableBL tableBL = new TableBL();
                // Cập nhật dữ liệu trong bảng
                return tableBL.Update(table);
            }
            return -1;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Gọi phương thức cập nhật dữ liệu
            int result = UpdateFood();
            if (result > 0) // Nếu cập nhật thành công
            {
                // Thông báo kết quả
                MessageBox.Show("Cập nhật dữ liệu thành công");
                // Tải lại dữ liệu cho ListView
                LoadTableToLV();
            }
            // Nếu thêm không thành công thì thông báo cho người dùng
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Hỏi người dùng có chắc chắn xoá hay không? Nếu đồng ý thì
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá mẫu tin này?", "Thông báo",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
                TableBL tableBL = new TableBL();
                if (tableBL.Delete(tableCurrent) > 0)// Nếu xoá thành công
                {
                    MessageBox.Show("Xoá thành công");
                    // Tải tữ liệu lên ListView
                    LoadTableToLV();
                }
                else MessageBox.Show("Xoá không thành công");
            }
        }

        private void lvTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvTable.Items.Count; i++)
            {
                //nếu có dòng được chọn thì lấy dòng đó
                if (lvTable.Items[i].Selected)
                {
                    tableCurrent = listTable[i];
                    txtName.Text = tableCurrent.Name;
                    txtStatus.Text = tableCurrent.Status.ToString();
                    txtCapacity.Text = tableCurrent.Capacity.ToString();
                }
            }
        }

        private void Table_Load(object sender, EventArgs e)
        {
            LoadTableToLV();
        }

        public void LoadTableToLV()
        {

            TableBL tableBL = new TableBL();
            listTable = tableBL.GetAll();
           // int count = 1;
            lvTable.Items.Clear();


            foreach (var table in listTable)
            {
                ListViewItem item = new ListViewItem("Bàn "+ table.Name,table.Status);
                lvTable.Items.Add(item);

            }
        }
    }
}
