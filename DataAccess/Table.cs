using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Table
    {
        public int ID { get; set; }

        //Tên bàn
        public string Name { get; set; }

        // trạng thái 0 là chưa có người, 1 là có người
        public int Status { get; set; }

        // Bàn dành cho mấy người
        public int Capacity { get; set; }
    }
}
