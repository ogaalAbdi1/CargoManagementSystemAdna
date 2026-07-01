using CargoManagementSytem.Model;
using Microsoft.Data.SqlClient;
 namespace CargoManagementSytem.Data
{
    public class ShipmentData
    {
        String Connection = @"Data Source=DESKTOP-L0KF10C\SQLEXPRESS;initial catalog=CargoMangementSytem;
                integrated security=true;TrustServerCertificate=True";

        // get all data
        // GET ALL
        public List<Shipments> GetShipments()
        {
            List<Shipments> list = new List<Shipments>();

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM Shipment";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Shipments
                {
                    ShipmentId = (int)dr["ShipmentId"],
                    Cargoid = (int)dr["CargoId"],
                    StatusId = (int)dr["StatusId"],
                    ShipmentData = (DateTime)dr["ShipmentDate"],
                    Destination = dr["Destination"].ToString(),
                    ExpectedDelivery = (DateTime)dr["ExpectedDelivery"]
                });
            }

            con.Close();
            return list;
        }
        public Shipments GetShipmentById(int id)
        {
            Shipments s = null;

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM Shipment WHERE ShipmentId=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s = new Shipments
                {
                    ShipmentId = (int)dr["ShipmentId"],
                    Cargoid = (int)dr["CargoId"],
                    StatusId = (int)dr["StatusId"],
                    ShipmentData = (DateTime)dr["ShipmentDate"],
                    Destination = dr["Destination"].ToString(),
                    ExpectedDelivery = (DateTime)dr["ExpectedDelivery"]
                };
            }

            con.Close();
            return s;
        }

        //insert
        // INSERT
        public bool AddShipment(Shipments ss)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = @"INSERT INTO Shipment
            (CargoId, StatusId, ShipmentDate, Destination, ExpectedDelivery)
            VALUES (@CargoId,@StatusId,@ShipmentDate,@Destination,@ExpectedDelivery)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@CargoId", ss.Cargoid);
            cmd.Parameters.AddWithValue("@StatusId", ss.StatusId);
            cmd.Parameters.AddWithValue("@ShipmentDate", ss.ShipmentData);
            cmd.Parameters.AddWithValue("@Destination", ss.Destination);
            cmd.Parameters.AddWithValue("@ExpectedDelivery", ss.ExpectedDelivery);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }
        // UPDATE
        public bool UpdateShipment(Shipments s)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = @"UPDATE Shipment SET
            CargoId=@CargoId,
            StatusId=@StatusId,
            ShipmentDate=@ShipmentDate,
            Destination=@Destination,
            ExpectedDelivery=@ExpectedDelivery
            WHERE ShipmentId=@ShipmentId";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ShipmentId", s.ShipmentId);
            cmd.Parameters.AddWithValue("@CargoId", s.Cargoid);
            cmd.Parameters.AddWithValue("@StatusId", s.StatusId);
            cmd.Parameters.AddWithValue("@ShipmentDate", s.ShipmentData);
            cmd.Parameters.AddWithValue("@Destination", s.Destination);
            cmd.Parameters.AddWithValue("@ExpectedDelivery", s.ExpectedDelivery);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }
        // DELETE
        public bool DeleteShipment(int id)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = "DELETE FROM Shipment WHERE ShipmentId=@id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }

    }


    }
