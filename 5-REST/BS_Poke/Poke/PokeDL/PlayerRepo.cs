using System.Data.SqlClient;

namespace PokeDL
{
    public class PlayerRepo : IRepository<Player>
    {
        private readonly string _connectionString;
        public PlayerRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public Player Add(Player p_resource)
        {
            string sqlQuery = @"Insert into Player(@name, @gender)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);
                
                //Setting parameters
                com.Parameters.AddWithValue("@name", p_resource.Name);
                com.Parameters.AddWithValue("@gender", p_resource.Gender);
                com.ExecuteNonQuery();
            }

            return p_resource;
        }

        public Player Delete(Player p_resource)
        {
            string sqlQuery = @"delete from Player
                                where playerId = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                //Setting Parameters
                com.Parameters.AddWithValue("@Id", p_resource.Id);

                com.ExecuteNonQuery();
            }
            
            return p_resource;
        }

        public List<Player> GetAll()
        {
            string sqlQuery = @"select * from Player";
            List<Player> listOfPlayer = new List<Player>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    listOfPlayer.Add(new Player(){
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Gender = reader.GetBoolean(2)
                    });
                }
            }

            return listOfPlayer;
        }

        public Player Update(Player p_resource)
        {
            string sqlQuery = @"update Player
                                set playerName = @name, playerGender = @gender
                                where playerId = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                com.Parameters.AddWithValue("@name", p_resource.Name);
                com.Parameters.AddWithValue("@gender", p_resource.Gender);
                com.Parameters.AddWithValue("@Id", p_resource.Id);
                com.ExecuteNonQuery();
            }
            
            return p_resource;
        }
    }
}