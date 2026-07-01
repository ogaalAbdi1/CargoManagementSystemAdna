using CargoManagementSytem.Model;
using System.Data;
using System.Data.SqlClient;

namespace CargoManagementSytem.Data
{
    public class UsersData

    {
        // create string connection varaible
        String Connection = @"Data Source=DESKTOP-L0KF10C\SQLEXPRESS;initial catalog=CargoMangementSytem;
            integrated security=true;TrustServerCertificate=True";
        //get all data
        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM Users";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                users.Add(new Users
                {
                    UserId = Convert.ToInt32(item["UserId"]),
                    UserName = item["Username"].ToString(),
                    Password = item["Password"].ToString(),
                    Role = item["Role"].ToString()
                });
            }

            return users;

        }

        // INSERT
        public void InsertUser(Users user)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = @"INSERT INTO Users
            (Username,Password,Role)
            VALUES
            (@Username,@Password,@Role)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Username", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Role", user.Role);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // UPDATE
        public void UpdateUser(Users user)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = @"UPDATE Users
            SET
                UserName=@UserName,
                Password=@Password,
                Role=@Role
            WHERE UserId=@UserId";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserId", user.UserId);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Role", user.Role);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // GET BY ID
        public Users? GetUserById(int id)
        {
            Users user = null;

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM Users WHERE UserId=@UserId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserId", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                user = new Users
                {
                    UserId = Convert.ToInt32(dr["UserId"]),
                    UserName = dr["UserName"].ToString(),
                    Password = dr["Password"].ToString(),
                    Role = dr["Role"].ToString()
                };
            }

            con.Close();

            return user;
        }


        // LOGIN
        public Users? Login(string username, string password)
        {
            Users user = null;

            SqlConnection con = new SqlConnection(Connection);

            string query = @"SELECT * FROM Users
                             WHERE UserName=@UserName
                             AND Password=@Password";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                user = new Users
                {
                    UserId = Convert.ToInt32(dr["UserId"]),
                    UserName = dr["UserName"].ToString(),
                    Password = dr["Password"].ToString(),
                    Role = dr["Role"].ToString()
                };
            }

            con.Close();

            return user;
        }



    }
}
