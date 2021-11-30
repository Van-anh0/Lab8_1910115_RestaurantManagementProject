using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;

namespace Lab8_1910115_RestaurantManagementProject
{
    public partial class CategoryForm : Form
    {
        List<Category>  ListCategory = new List<Category>();
        Category CategoryCurrent = new Category();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategoryToListView();
        }

        private void LoadCategoryToListView()
        {

            //Gọi đối tượng FoodBL từ tầng BusinessLogic
            CategoryBL categoryBL = new CategoryBL();
            // Lấy dữ liệu
            ListCategory = categoryBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvCategory.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var category in ListCategory)
            {
                // Số thứ tự
                ListViewItem item = lvCategory.Items.Add(count.ToString());
                // Đưa dữ liệu Name, Unit, price vào cột tiếp theo
                item.SubItems.Add(category.Name);
                item.SubItems.Add(category.Type.ToString());
               
               
                count++;
            }
        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            // Duyệt toàn bộ dữ liệu trong ListView
            for (int i = 0; i < lvCategory.Items.Count; i++)
            {
                // Nếu có dòng được chọn thì lấy dòng đó
                if (lvCategory.Items[i].Selected)
                {// Lấy các tham số và gán dữ liệu vào các ô
                    CategoryCurrent = ListCategory[i];
                    txtName.Text = CategoryCurrent.Name;
                    cbbType.Text = CategoryCurrent.Type.ToString();
                }

            }
        }

        public int InsertCategory()
        {
            //Khai báo đối tượng Food từ tầng DataAccess
            Category category = new Category();
            category.ID = 0;
            // Kiểm tra nếu các ô nhập khác rỗng 
            if (txtName.Text == "" || cbbType.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name, Unit, và Notes từ người dùng nhập vào
                category.Name = txtName.Text;
                category.Type = int.Parse(cbbType.Text);
                
                CategoryBL categoryBL = new CategoryBL();
                // Chèn dữ liệu vào bảng
                return categoryBL.Insert(category);
            }
            return -1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Gọi phương thức thêm dữ liệu
            int result = InsertCategory();
            if (result > 0) // Nếu thêm thành công
            {
                // Thông báo kết quả
                MessageBox.Show("Thêm dữ liệu thành công");
                // Tải lại dữ liệu cho ListView
                LoadCategoryToListView();
            }
            // Nếu thêm không thành công thì thông báo cho người dùng
            else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        public int UpdateFood()
        {
           
            Category category = CategoryCurrent;
            // Kiểm tra nếu các ô nhập khác rỗng
            if (txtName.Text == "" || cbbType.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                
                category.Name = txtName.Text;
                category.Type = int.Parse(cbbType.Text);
                
                CategoryBL categoryBL = new CategoryBL();
                // Cập nhật dữ liệu trong bảng
                return categoryBL.Update(category);
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
                LoadCategoryToListView();
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
                // Khai báo đối tượng FoodBL từ BusinessLogic
                CategoryBL categoryBL = new CategoryBL();
                if (categoryBL.Delete(CategoryCurrent) > 0)// Nếu xoá thành công
                {
                    MessageBox.Show("Xoá thực phẩm thành công");
                    // Tải tữ liệu lên ListView
                    LoadCategoryToListView();
                }
                else MessageBox.Show("Xoá không thành công");
            }
        }
    }
}
