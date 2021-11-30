using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccess;

namespace DataAccess
{
    //lớp quản lý Table
    public class TableDA
    {
        //phương thức lấy hết dữ liệu theo thủ tục Table_GetAll
        public List<Table> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Table_GetAll;

            //đọc dữ liệu, trả về danh sách các đối tượng table
            SqlDataReader reader = command.ExecuteReader();
            List<Table> list = new List<Table>();
            while (reader.Read())
            {
                Table t = new Table();
                t.ID = Convert.ToInt32(reader["ID"]);
                t.Name = reader["Name"].ToString();
                t.Status = Convert.ToInt32(reader["Status"]);
                t.Capacity = Convert.ToInt32(reader["Capacity"]);
                list.Add(t);
            }
            //đóng kết nối và trả về danh sách
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Table table, int action)
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Table_InsertUpdateDelete;

            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.InputOutput; // vừa vào vừa ra
            command.Parameters.Add(ID).Value = table.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = table.Name;
            command.Parameters.Add("@Status", SqlDbType.Int).Value = table.Status;
            command.Parameters.Add("@Capacity", SqlDbType.Int).Value = table.Capacity;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            // thực thi lệnh
            int result = command.ExecuteNonQuery();
            if (result > 0) //nếu thành công thì trả về ID đã thêm
                return (int)command.Parameters["@ID"].Value;
            return 0;
        }
    }
}
