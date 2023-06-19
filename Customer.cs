using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Webshop
{
    public class Customer
    {
            
       public string name;
       public string address;
       public int phone;
        public string email;
        SqlConnection con;
        public Customer(string name, string address, int phone, string email, string conString) 
        {
            this.name = name; 
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.con = new SqlConnection(conString);
        }

        public void AddCustomerToSql()
        {
            string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
               
                
                    con.Open();
                    string query = @"INSERT INTO Customer VALUES(@name, @address, @phone, @email)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    con.Close();

                
            }catch (Exception ex)
            {

            }
        }
      
        public void ChangeName(string newName)
        {
            string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";
            try
            {
                
                
                    con.Open();
                    string updateQuery = @"UPDATE Customer SET name = @newName WHERE email = @email";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@newName", newName);
                    updateCmd.Parameters.AddWithValue("@email", email);
                    updateCmd.ExecuteNonQuery();
                    con.Close();
                
                this.name = newName;
            }
             catch (Exception ex)
            {
            }
        }
    }   
}
