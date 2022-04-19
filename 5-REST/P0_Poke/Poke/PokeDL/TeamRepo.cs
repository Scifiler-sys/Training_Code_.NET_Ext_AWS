using System.Data.SqlClient;

namespace PokeDL
{
    public class TeamRepo : IRepository<Team>
    {
        private readonly string _connectionString;
        public TeamRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public Team Add(Team p_resource)
        {
            string sqlQuery = @"Insert into Team values(@level, @playerId, @pokeId)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);
                
                //Setting parameters
                com.Parameters.AddWithValue("@level", p_resource.PokeLevel);
                com.Parameters.AddWithValue("@playerId", p_resource.PlayerId);
                com.Parameters.AddWithValue("@pokeId", p_resource.PokeId);

                com.ExecuteNonQuery();
            }

            return p_resource;
        }

        public Team Delete(Team p_resource)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAll()
        {
            string sqlQuery = @"select * from Team";
            List<Team> listOfTeam = new List<Team>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    listOfTeam.Add(new Team(){
                        TeamId = reader.GetInt32(0),
                        PokeLevel = reader.GetInt32(1),
                        PlayerId = reader.GetInt32(2),
                        PokeId = reader.GetInt32(3),
                    });
                }
            }

            return listOfTeam;
        }

        public Team Update(Team p_resource)
        {
            throw new NotImplementedException();
        }
    }
}