using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace BussinessLogic
{
    // có các phương thức xử lý bảng Table
    public class TableBL
    {
        TableDA tableDA = new TableDA();

        public List<Table> GetAll()
        {
            return tableDA.GetAll();
        }

        public int Insert(Table table)
        {
            return tableDA.Insert_Update_Delete(table, 0);
        }

        public int Update(Table table)
        {
            return tableDA.Insert_Update_Delete(table, 1);
        }

        public int Delete(Table table)
        {
            return tableDA.Insert_Update_Delete(table, 2);
        }
    }
}
