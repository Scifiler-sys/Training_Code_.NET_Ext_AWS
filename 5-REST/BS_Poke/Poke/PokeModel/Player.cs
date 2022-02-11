namespace PokeModel
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// true for female, false for male
        /// </summary>
        public bool Gender { get; set; }
    }
}