using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop
{
    public class WebshopApp
    {
        SqlConnection sqlCon;
        public WebshopApp(string sqlString) 
        {
            sqlCon = new SqlConnection(sqlString);
        }
        public void viewCustomer(int id)
        {

            sqlCon.Open();
            string query = @"SELECT name, address, phone, Email FROM customer WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    string name  = dr.GetString(0);
                    string address = dr.GetString(1);
                    int phone = dr.GetInt32(2);
                    string email = dr.GetString(3);
                    Customer customer = new Customer(name, address, phone, email, "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True");
                    Console.WriteLine(customer.name);
                }
            }
            sqlCon.Close();

        }
        public void addCustomer(Customer customer) 
        {
            try
            {
                sqlCon.Open();
                string checkQuery = @"SELECT COUNT(*) FROM customer WHERE phone = @phone OR email = @email";
                SqlCommand checkCmd = new SqlCommand(checkQuery, sqlCon);
                checkCmd.Parameters.AddWithValue("@phone", customer.phone);
                checkCmd.Parameters.AddWithValue("@Email", customer.email);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine("Customer already exsist");
                    return;
                }

                string query = @"INSERT INTO customer (name, address, phone, email) VALUES (@name, @address, @phone, @email)";
                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@address", customer.address);
                cmd.Parameters.AddWithValue("@phone", customer.phone);
                cmd.Parameters.AddWithValue("@email", customer.email);
                cmd.ExecuteNonQuery();
                sqlCon.Close();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }
        }
        public void RemoveCustomer(int id) 
        {   
            sqlCon.Open();
            string query = $"DELETE FROM customer WHERE id = {id}";
            SqlCommand cmd = new SqlCommand(query, sqlCon); 
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }
    }
}
