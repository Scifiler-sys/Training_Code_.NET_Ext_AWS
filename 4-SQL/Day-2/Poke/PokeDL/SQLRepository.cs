using System.Data.SqlClient;

namespace PokeDL
{
    public class SQLRepository : IRepository
    {
        private readonly string _connectionString;
        public SQLRepository(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public Pokemon AddPokemon(Pokemon p_poke)
        {
            //@ before the string makes it so it ignores special characters like \n
            //@ inside the string acts as parameters (think of when we did $"{some variable}")
            string sqlQueryString = @"insert into Pokemon
                                    values(@name, @level,@attack,@health,@defense)";

            //using block is different from your normal using statement
            //It is used to automatically close any resource you stated that you will be using in the parenthesis
            //It will close as soon as you finish doing the using block (it even closes the resource even if an exception occurs which is really handy)
            using (SqlConnection con = new SqlConnection(_connectionString)) //In this case, I want the Sqlconnection to close to the database as soon as it finishes its operations
            {
                //Opens the connection to the database
                con.Open();

                //SqlCommand class is a class specialized for executing SQL statements
                SqlCommand command = new SqlCommand(sqlQueryString, con);

                //Inserting the parameters of the sqlQueryString with our pokemon properties
                //Why do this when you can just do $"insert into Pokemon values({p_poke.Name}"
                //To protect against SQLinjection attacks
                command.Parameters.AddWithValue("@name", p_poke.Name);
                command.Parameters.AddWithValue("@level", p_poke.Level);
                command.Parameters.AddWithValue("@attack", p_poke.Attack);
                command.Parameters.AddWithValue("@health", p_poke.Health);
                command.Parameters.AddWithValue("@defense", p_poke.Defense);

                //Executes the sql statement
                command.ExecuteNonQuery();
            }
            
            return p_poke;
        }

        public List<Pokemon> GetAllPokemon()
        {
            string sqlQueryString = @"select * from Pokemon";
            List<Pokemon> listOfPoke = new List<Pokemon>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQueryString, con);

                //SQLDataReader class specializes in reading the output of the sql statement
                //Remember that sql gives you tables... C# doesn't understand table as a datatype sooo we have some manual converting to do
                SqlDataReader reader = command.ExecuteReader();

                //Read() methods just checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                    //will add a new pokemon object to our list that has the same data in our database
                    listOfPoke.Add(new Pokemon()
                    {
                        //Note: the starting index for columns is 1 and not 0
                        Name = reader.GetString(1), //the number we specify is the column of the table, so in this case it will be name column
                        Level = reader.GetInt32(2), //column 2 is our level in the poke database
                        Attack = reader.GetInt32(3),
                        Health = reader.GetInt32(4),
                        Defense = reader.GetInt32(5)
                    });
                }
            }
            
            return listOfPoke;
        }
    }
}