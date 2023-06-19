using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Webshop
{
    internal static class Connect
    {



        public static void ConnectSql ()
        {

            string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string query = "SELECT id, name FROM customer"; 
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                   
                    SqlDataReader dr = cmd.ExecuteReader();
                            
                    if (dr.HasRows) 
                    {
                        while (dr.Read())
                        {
                            int id = dr.GetInt32(0);
                            string navn = dr.GetString(1);
                            Console.WriteLine(id + "," + navn);
                        }
                    }
                    dr.Close();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
    }
}

//hi 
