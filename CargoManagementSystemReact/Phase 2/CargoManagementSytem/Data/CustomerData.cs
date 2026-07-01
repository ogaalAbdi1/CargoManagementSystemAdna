using CargoManagementSytem.Model;
using Microsoft.Data.SqlClient;
using System.Data;
namespace CargoManagementSytem.Data
{
    public class CustomerData
    {
        // create string connection varaible
            String Connection = @"Data Source=DESKTOP-L0KF10C\SQLEXPRESS;initial catalog=CargoMangementSytem;
            integrated security=true;TrustServerCertificate=True";

        //method used get fron sql server
        public List<Customer> GetDataCustomer() 

        { 
            //create list
            //properties in aan ku dhex socdo
            List<Customer> Customersr = new List<Customer>();

            //create sql connection
            SqlConnection con=new SqlConnection(Connection);

            //create query
            string query = "select * from  Customer";

            //usig sql dataadapter
            SqlDataAdapter da=new SqlDataAdapter(query, con);

            //create datatable
            DataTable dt=new DataTable();
            da.Fill(dt);

            //foreach used data rows
            foreach(DataRow item in dt.Rows)
            {
                //create objects
                Customersr.Add(new Customer
                {
                    CustomerId = int.Parse(item["CustomerId"].ToString()),
                    FullName = item["FullName"].ToString(),
                    Phone = (item["Phone"].ToString()),
                    Email = item["Email"].ToString(),
                    Address = item["Address"].ToString()

                });
     

                
            }

            return Customersr;

        }

        //metod used to insert data
        public void insertdata (Customer Addcustomer)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = "insert into Customer(FullName,Phone,Email,Address)" +
               "values(@FullName,@Phone,@Email,@Address)";

            //sql command 
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FullName",Addcustomer.FullName);
            cmd.Parameters.AddWithValue("@Phone", Addcustomer.Phone);
            cmd.Parameters.AddWithValue("@Email", Addcustomer.Email);
            cmd.Parameters.AddWithValue("@Address", Addcustomer.Address);

            con.Open();
            //insert update date qabto methods kaan
            cmd.ExecuteNonQuery();
            con.Close();


        }


        //update in la sameeyo xogtii databse ka ku jirtay

        public void UpdateCustomer(Customer customer)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = @"UPDATE Customer
                     SET FullName=@FullName,
                         Phone=@Phone,
                         Email=@Email,
                         Address=@Address
                     WHERE CustomerId=@CustomerId";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@FullName", customer.FullName);
            cmd.Parameters.AddWithValue("@Phone", customer.Phone);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Address", customer.Address);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool DeleteCustomer(int id)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = "DELETE FROM Customer WHERE CustomerId=@CustomerId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CustomerId", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }

        //get by id

        public Customer? GetCustomerById(int id)
        {
            Customer customer = null;

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM Customer WHERE CustomerId=@CustomerId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CustomerId", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                customer = new Customer
                {
                    CustomerId = Convert.ToInt32(dr["CustomerId"]),
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Email = dr["Email"].ToString(),
                    Address = dr["Address"].ToString()
                };
            }

            con.Close();

            return customer;
        }

    }
   
}
