using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Fahasa.DAO
{
    class Connect
    {
        //tạo chuỗi kết nối
        //private string connectString = "Data Source=(local); pwd=12345;Initial Catalog = FahasaBookStore; Integrated Security = True";
        private string connectString = "Data Source=LAPTOP-D3KN8KNR;Initial Catalog=FahasaBookStore;Integrated Security=True";
        //Tạo đối tượng SqlConnection
        public SqlConnection getconnect()
        {
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            //MessageBox.Show("Đã kết nối");
            return conn;
        }
        public int ExcuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlCommand excute = new SqlCommand(query, connect);
                data = excute.ExecuteNonQuery();
                connect.Close();
            }
            return data;
        }
        public DataTable ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlCommand excute = new SqlCommand(query, connect);
                SqlDataAdapter getdata = new SqlDataAdapter(excute);
                getdata.Fill(dt);
                connect.Close();
            }
            return dt;
        }
        public DataTable Publisher()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Publisher", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Supplier()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Supplier", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Author()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Author", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable ProductGroup()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_ProductGroup", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Genre()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Genre", getconnect());
            adapter.Fill(data);
            return data;
        }

        public DataTable GenreType()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_GenreType", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Brand()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Brand", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Origin()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Origin", getconnect());
            adapter.Fill(data);
            return data;
        }

        public DataTable Product()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Product", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Order()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Orders", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable OrderDetail()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_OrderDetail", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Inventory()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Inventory", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Customer()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Customer", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Price()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Price", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Branch()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Branch", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Employee()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Employee", getconnect());
            adapter.Fill(data);
            return data;
        }
        public DataTable Invoice()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM v_Invoice", getconnect());
            adapter.Fill(data);
            return data;
        }





    }
}
