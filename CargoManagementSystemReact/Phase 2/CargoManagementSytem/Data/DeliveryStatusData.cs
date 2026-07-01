using CargoManagementSytem.Model;
using Microsoft.Data.SqlClient;
namespace CargoManagementSytem.Data
{
    public class DeliveryStatusData
    {
        // create string connection varaible
        String Connection = @"Data Source=DESKTOP-L0KF10C\SQLEXPRESS;initial catalog=CargoMangementSytem;
            integrated security=true;TrustServerCertificate=True";
        //get all dat
        public List<DeliveryStatus> GetAll()
        {
            List<DeliveryStatus> alldeliverystatus = new List<DeliveryStatus>();

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM DeliveryStatus";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                alldeliverystatus.Add(new DeliveryStatus
                {
                    StatusId = (int)dr["StatusId"],
                    StatusName = dr["StatusName"].ToString(),
                    Description = dr["Descriptions"].ToString()
                });
            }

            con.Close();
            return alldeliverystatus;
        }
        // ✅ GET BY ID
        public DeliveryStatus GetById(int id)
        {
            DeliveryStatus s = null;

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM DeliveryStatus WHERE StatusId=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                s = new DeliveryStatus
                {
                    StatusId = (int)dr["StatusId"],
                    StatusName = dr["StatusName"].ToString(),
                    Description = dr["Descriptions"].ToString()
                };
            }

            con.Close();
            return s;
        }
        // ✅ INSERT
        public bool Insert(DeliveryStatus s)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = "INSERT INTO DeliveryStatus (StatusName, Descriptions) VALUES (@n, @d)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@n", s.StatusName);
            cmd.Parameters.AddWithValue("@d", s.Description);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }
        // ✅ UPDATE
        public bool Update(DeliveryStatus s)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = @"UPDATE DeliveryStatus SET
                            StatusName=@n,
                            Descriptions=@d
                            WHERE StatusId=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", s.StatusId);
            cmd.Parameters.AddWithValue("@n", s.StatusName);
            cmd.Parameters.AddWithValue("@d", s.Description);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }
        // ✅ DELETE
        public bool Delete(int id)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = "DELETE FROM DeliveryStatus WHERE StatusId=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }
    }
}
