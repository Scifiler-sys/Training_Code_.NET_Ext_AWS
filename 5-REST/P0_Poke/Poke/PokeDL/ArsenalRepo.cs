using System.Data.SqlClient;

namespace PokeDL
{
    public class ArsenalRepo : IRepository<Arsenal>
    {
        private readonly string _connectionString;
        public ArsenalRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public Arsenal Add(Arsenal p_resource)
        {
            string sqlQuery = @"Insert into Arsenal values (@pokeId, @abId, @PP)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);
                
                //Setting parameters
                com.Parameters.AddWithValue("@pokeId", p_resource.TeamId);
                com.Parameters.AddWithValue("@abId", p_resource.AbId);
                com.Parameters.AddWithValue("@PP", p_resource.CurrentPP);

                com.ExecuteNonQuery();
            }

            return p_resource;
        }

        public Arsenal Delete(Arsenal p_resource)
        {
            string sqlQuery = @"delete from Arsenal
                                where abId = @abId and pokeId = @pokeId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                //Setting Parameters
                com.Parameters.AddWithValue("@abId", p_resource.AbId);
                com.Parameters.AddWithValue("@pokeId", p_resource.TeamId);

                com.ExecuteNonQuery();
            }
            
            return p_resource;
        }

        public List<Arsenal> GetAll()
        {
            string sqlQuery = @"select * from Arsenal";
            List<Arsenal> listOfAbility = new List<Arsenal>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    listOfAbility.Add(new Arsenal(){
                        TeamId = reader.GetInt32(0),
                        AbId = reader.GetInt32(1),
                        CurrentPP = reader.GetInt32(2)
                    });
                }
            }

            return listOfAbility;
        }

        public Arsenal Update(Arsenal p_resource)
        {
            string sqlQuery = @"update Ability
                                set PP = @PP
                                where abId = @abId and pokeId = @pokeId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                com.Parameters.AddWithValue("@abId", p_resource.AbId);
                com.Parameters.AddWithValue("@pokeId", p_resource.TeamId);
                com.Parameters.AddWithValue("@PP", p_resource.CurrentPP);

                com.ExecuteNonQuery();
            }
            
            return p_resource;
        }   
    }
}