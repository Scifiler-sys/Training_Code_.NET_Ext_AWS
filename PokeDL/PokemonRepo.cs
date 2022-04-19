using System.Data.SqlClient;

namespace PokeDL
{
    public class PokemonRepo : IRepository<Pokemon>
    {
        private readonly string _connectionString;
        public PokemonRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public Pokemon Add(Pokemon p_resource)
        {
            string sqlQuery = @"Insert into Pokemon output inserted.pokeId values(@name, @level, @attack, @defense, @health, @speed, @type)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);
                
                //Setting parameters
                com.Parameters.AddWithValue("@name", p_resource.Name);
                com.Parameters.AddWithValue("@level", p_resource.Level);
                com.Parameters.AddWithValue("@attack", p_resource.Attack);
                com.Parameters.AddWithValue("@defense", p_resource.Defense);
                com.Parameters.AddWithValue("@health", p_resource.Health);
                com.Parameters.AddWithValue("@speed", p_resource.Speed);
                com.Parameters.AddWithValue("@type", p_resource.Type);

                p_resource.Id = (int)com.ExecuteScalar();
            }

            return p_resource;
        }

        public Pokemon Delete(Pokemon p_resource)
        {
            string sqlQuery = @"delete from Pokemon
                                output delete.
                                where pokeId = @Id";

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

        public List<Pokemon> GetAll()
        {
            string sqlQuery = @"select * from Pokemon";
            List<Pokemon> listOfPoke = new List<Pokemon>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    listOfPoke.Add(new Pokemon(){
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Level = reader.GetInt32(2),
                        Attack = reader.GetInt32(3),
                        Defense = reader.GetInt32(4),
                        Health = reader.GetInt32(5),
                        Speed = reader.GetInt32(6),
                        Type = reader.GetString(7)
                    });
                }
            }

            return listOfPoke;
        }

        public Pokemon Update(Pokemon p_resource)
        {
            string sqlQuery = @"update Pokemon
                                set pokeName = @name, pokeLevel = @level, pokeAttack = @attack, pokeDefense = @defense, pokeHealth = @health
                                where pokeId = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                com.Parameters.AddWithValue("@name", p_resource.Name);
                com.Parameters.AddWithValue("@level", p_resource.Level);
                com.Parameters.AddWithValue("@attack", p_resource.Attack);
                com.Parameters.AddWithValue("@defense", p_resource.Defense);
                com.Parameters.AddWithValue("@Id", p_resource.Id);

                com.ExecuteNonQuery();
            }
            
            return p_resource;
        }
    }
}