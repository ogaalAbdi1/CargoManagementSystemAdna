using CargoManagementSytem.Model;
using Microsoft.Data.SqlClient;
namespace CargoManagementSytem.Data
{
    public class CargoData
    {
        // create string connection varaible
        String Connection = @"Data Source=DESKTOP-L0KF10C\SQLEXPRESS;initial catalog=CargoMangementSytem;
                integrated security=true;TrustServerCertificate=True";

        public List<Cargo> GetCargos()
        {
            List<Cargo> cargos = new List<Cargo>();


            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM Cargo";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cargo cargo = new Cargo
                {
                    CargoId = Convert.ToInt32(reader["CargoId"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    CargoName = reader["CargoName"].ToString(),
                    Weight = Convert.ToDecimal(reader["Weight"]),
                    CargoType = reader["CargoType"].ToString()
                };
                cargos.Add(cargo);



            }
            return cargos;


            //inser data cargo table




        }

        //insert data cargo table

        public string AddCargo(Cargo cargo)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                string query = @"INSERT INTO Cargo (CustomerId, CargoName, Weight, CargoType)
                         VALUES (@CustomerId, @CargoName, @Weight, @CargoType)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CustomerId", cargo.CustomerId);
                cmd.Parameters.AddWithValue("@CargoName", cargo.CargoName);
                cmd.Parameters.AddWithValue("@Weight", cargo.Weight);
                cmd.Parameters.AddWithValue("@CargoType", cargo.CargoType);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return "Cargo inserted successfully";
        }




        //updated data for table cargo

        public string UpdateCargo(Cargo cargo)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                string query = @"UPDATE Cargo 
                         SET CustomerId=@CustomerId,
                             CargoName=@CargoName,
                             Weight=@Weight,
                             CargoType=@CargoType
                         WHERE CargoId=@CargoId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CargoId", cargo.CargoId);
                cmd.Parameters.AddWithValue("@CustomerId", cargo.CustomerId);
                cmd.Parameters.AddWithValue("@CargoName", cargo.CargoName);
                cmd.Parameters.AddWithValue("@Weight", cargo.Weight);
                cmd.Parameters.AddWithValue("@CargoType", cargo.CargoType);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                if (rows == 0)
                    return "Cargo not found";

                return "Cargo updated successfully";
            }
        }
        //get by id

        public Cargo GetCargoById(int id)
        {
            Cargo cargo = null;

            SqlConnection con = new SqlConnection(Connection);

            string query = "SELECT * FROM Cargo WHERE CargoId=@CargoId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CargoId", id);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cargo = new Cargo
                {
                    CargoId = Convert.ToInt32(reader["CargoId"]),
                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                    CargoName = reader["CargoName"].ToString(),
                    Weight = Convert.ToDecimal(reader["Weight"]),
                    CargoType = reader["CargoType"].ToString()
                };
            }

            con.Close();
            return cargo;
        }
        //delete
        public bool DeleteCargo(int id)
        {
            SqlConnection con = new SqlConnection(Connection);

            string query = "DELETE FROM Cargo WHERE CargoId=@CargoId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CargoId", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }

    }
}
