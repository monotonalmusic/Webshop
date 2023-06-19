using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Webshop
{
    internal class produkt
    {

        string name;
        string amount;
        int order_id;
        public produkt(string name, string amount, int order_id)
        {
            this.name = name;
            this.amount = amount;
            this.order_id = order_id;

        }

        public void AddToSqlServer()
        {
            string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string query = $"INSERT INTO product VALUES('{name}', '{amount}', '{order_id}' ";
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
