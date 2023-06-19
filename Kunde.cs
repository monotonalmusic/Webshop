using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Webshop
{
    public class Kunde
    {
            
        string navn;
        string adresse;
        string telefon;
        string email;
        public Kunde(string navn, string adresse, string telefon, string email) 
        {
            this.navn = navn; 
            this.adresse = adresse;
            this.telefon = telefon;
            this.email = email;
            
        }

        public void AddKundeToSql()
        {
            string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    string query = $"INSERT INTO Ordre VALUES('{navn}', '{adresse}', '{telefon}', '{email}') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }catch (Exception ex)
            {

            }
        }
        public void
    }
}
