using PHCN.ThuNoiBo.Client.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHCN.ThuNoiBo.Client.Controller
{
    public class ClientController
    {
        DBAccess dbAccess = new DBAccess();
        public DataTable runQuery(string query)
        {
            SqlConnection conn = dbAccess.GetConnect();            
            using (SqlCommand cmd = new SqlCommand())
            {
                DataTable dt = new DataTable();
                cmd.CommandText = query;
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
                
        }
    }
}
