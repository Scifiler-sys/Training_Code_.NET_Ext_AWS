﻿namespace PokeModel
{
    public class Pokemon
    {
        //Random class is made for us to get a randomly generated number
        //.Next() method is how it gets a random number
        protected Random _rand = new Random();
        public Pokemon()
        {
            this.Name = "Ditto";
            this.Level = 1;
            this.Attack = 55;
            this.Health = 55;
            this.Defense = 55;
            this._abilities = new List<Ability>(){new Ability()};
        }

        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        private List<Ability> _abilities;
        public List<Ability> Abilities
        {
            get { return _abilities; }
            set 
            { 
                if (value.Count < 5 && value.Count > 0)
                {
                    _abilities = value;
                }
                else if (value.Count == 0)
                {
                    throw new Exception("A pokemon must have 1 ability");
                }
                else
                {
                    throw new Exception("A pokemon can only have 4 abilities");
                }
            }
        }

        public override string ToString()
        {
            return $"===Pokemon Info===\nTeamId: {TeamId}\nName: {Name} Lv: {Level}\nHealth: {Health}\nAttack: {Attack}\nDefense: {Defense}\nSpeed: {Speed}\nType: {Type}";
        }
    }
}
