using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop
{
    public class Order
    {
        
        string weight;
        string date;
        string delivery_address;
        int customer_id;
        SqlConnection con;
        public Order(string weight, string date, string delivery_address, int customer_id, string conString) 
        {
            this.weight = weight; 
            this.date = date;
            this.delivery_address = delivery_address;
            this.customer_id = customer_id;
            this.con = new SqlConnection(conString);


        }

        public void AddToSqlServer()
        {
         //    = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
               
                
                    con.Open();
                    string query = $"INSERT INTO Order VALUES('{weight}', '{date}', '{delivery_address}', {customer_id}) ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                
            }catch (Exception ex)
            {

            }
        }
        public void SetMailToKundeMail()
        {
            try
            {
            
               
                    con.Open();
                  //  string query = @"UPDATE Order";
                    

                
            }
            catch (Exception ex)
            {

            }
        }
        
    }
        
}
