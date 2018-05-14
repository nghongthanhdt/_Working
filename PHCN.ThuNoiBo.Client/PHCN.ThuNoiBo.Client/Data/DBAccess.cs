using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PHCN.ThuNoiBo.Client.Data
{
    public class DBAccess
    {
        public string connectionString = "";
        string _PathConFig = @"C:\configThuNoiBo.xml";
        private void GetConnectionString()
        {
            // bắt đầu đọc file config, gắn về clientConfig
            ClientConfig clientConfig = new ClientConfig();
            XmlSerializer serializer = new XmlSerializer(typeof(ClientConfig));
            StreamReader reader = new StreamReader(_PathConFig);
            clientConfig = (ClientConfig)serializer.Deserialize(reader);
            reader.Close();
            connectionString = "Data Source=" + clientConfig.ConnectServer + ";Initial Catalog=" + clientConfig.Database + "; User ID=" + clientConfig.ConnectUserName + "; Password=" + clientConfig.ConnectPassword + "; Connection Timeout=5";
        }

        public SqlConnection GetConnect()
        {
            GetConnectionString();
            SqlConnection conn = new SqlConnection(connectionString);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
                return conn;
            } else
            {
                return conn;
            }
        }
    }
}
