using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Data
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\105-2\HW\ConsoleApplication1\ConsoleApplication1\data\musicdata.mdf;Integrated Security=True";


        public void Createtitle(Models.music Music)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    music(title, name, starttime, endtime, price,create)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')
", Music.title.Replace(@"'",@"''"), Music.name, Music.starttime, Music.endtime, Music.price, Music.create.ToString("yyyy/MM/dd"));

            command.ExecuteNonQuery();


            connection.Close();
        }
        public List<Models.music> ReadMusic()
        {
            var result = new List<Models.music>();
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from music");
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.music item = new Models.music() ;
                item.title = reader["title"].ToString();
                item.name = reader["name"].ToString();
                item.starttime = reader["starttime"].ToString();
                item.endtime = reader["endtime"].ToString();
                item.price = reader["price"].ToString();
                item.create =DateTime.Parse(reader["create"].ToString());
                result.Add(item);
            }

            connection.Close();
            return result;
        } 
    }
}