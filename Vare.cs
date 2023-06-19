using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Webshop
{
    internal class Vare
    {

        string navn;
        string antal;
        int vare_id;
        public Vare(string navn, string antal, int vare_id)
        {
            this.navn = navn;
            this.antal = antal;
            this.vare_id = vare_id;

        }

        public void AddToSqlServer()
        {
            string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string query = $"INSERT INTO Vare VALUES('{navn}', '{antal}', '{vare_id}' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
