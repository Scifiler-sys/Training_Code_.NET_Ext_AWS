using System.Data.SqlClient;

namespace PokeDL
{
    public class AbilityRepo : IRepository<Ability>
    {
        private readonly string _connectionString;
        public AbilityRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public Ability Add(Ability p_resource)
        {
            string sqlQuery = @"Insert into Ability(@name, @PP, @power, @accuracy)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);
                
                //Setting parameters
                com.Parameters.AddWithValue("@name", p_resource.Name);
                com.Parameters.AddWithValue("@PP", p_resource.PP);
                com.Parameters.AddWithValue("@power", p_resource.Power);
                com.Parameters.AddWithValue("@accuracy", p_resource.Accuracy);

                com.ExecuteNonQuery();
            }

            return p_resource;
        }

        public Ability Delete(Ability p_resource)
        {
            string sqlQuery = @"delete from Pokemon
                                where abId = @Id";

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

        public List<Ability> GetAll()
        {
            string sqlQuery = @"select * from Ability";
            List<Ability> listOfAbility = new List<Ability>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    listOfAbility.Add(new Ability(){
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PP = reader.GetInt32(2),
                        Power = reader.GetInt32(3),
                        Accuracy = reader.GetInt32(4)
                    });
                }
            }

            return listOfAbility;
        }

        public Ability Update(Ability p_resource)
        {
            string sqlQuery = @"update Ability
                                set abName = @name, abPP = @PP, abPower = @power, abAccuracy = @accuracy
                                where abId = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                com.Parameters.AddWithValue("@name", p_resource.Name);
                com.Parameters.AddWithValue("@PP", p_resource.PP);
                com.Parameters.AddWithValue("@power", p_resource.Power);
                com.Parameters.AddWithValue("@accuracy", p_resource.Accuracy);
                com.Parameters.AddWithValue("@Id", p_resource.Id);

                com.ExecuteNonQuery();
            }
            
            return p_resource;
        }
    }
}