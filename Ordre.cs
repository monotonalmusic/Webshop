using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop
{
    public class Ordre
    {
        
        string vægt;
        string dato;
        string forsendelses_adresse;
        int kunde_id;
        public Ordre(string vægt, string dato, string forsendelses_adresse, int kunde_id) 
        {
            this.vægt = vægt; 
            this.dato = dato;
            this.forsendelses_adresse = forsendelses_adresse;
            this.kunde_id = kunde_id;
            
        }

        public void AddToSqlServer()
        {
            string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string query = $"INSERT INTO Ordre VALUES('{vægt}', '{dato}', '{forsendelses_adresse}', {kunde_id}) ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }catch (Exception ex)
            {

            }
        }
        
    }
        
}
