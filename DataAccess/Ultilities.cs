using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    class Ultilities
    {
        // lấy chuỗi kết nối từ tập tin App.Config
        private static string StrName = "ConnectionStringName";
        public static string ConnectionString = ConfigurationManager
        .ConnectionStrings[StrName]
        .ConnectionString;
        // Các biến của bảng Food
        public static string Food_GetAll = "Food_GetAll";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";
        // Các biến của bảng Category
        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete =
       "Category_InsertUpdateDelete";

        // các biến của bảng Table
        public static string Table_GetAll = "Table_GetAll";
        public static string Table_InsertUpdateDelete = "Table_InsertUpdateDelete";
    }
}
