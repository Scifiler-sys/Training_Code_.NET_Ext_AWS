﻿namespace PokeModel
{
    public class Pokemon
    {
        public Pokemon()
        {
            this.Name = "Ditto";
            this.Attack = 55;
            this.Health = 55;
            this.Defense = 55;
            this._abilities = new List<Ability>(){new Ability()};
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
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
            return $"===Pokemon Info===\nName: {Name}\nHealth: {Health}\nAttack: {Attack}\nDefense: {Defense}";
        }
    }
}