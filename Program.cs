using Webshop;
string conString = "Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True";

Customer customer = new Customer("Kim", "123465", 1235, "135@test.dk", conString);
// WebshopApp webshop = new WebshopApp("Data Source=DESKTOP-I5TRKAB\\SQLEXPRESS;Initial Catalog=Webshop;Integrated Security=True");
customer.AddCustomerToSql();
customer.ChangeName("Torben");
