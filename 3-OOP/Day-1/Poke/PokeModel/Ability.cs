namespace PokeModel
{
    public class Ability
    {
        public Ability()
        {
            this.Name = "Tackle";
            this.PP = 35;
            this.Power = 40;
            this.Accuracy = 100;
        }

        public string Name { get; set; }
        
        private int _PP;
        //In pokemon, this just means how many times you can use the ability during a battle
        public int PP
        {
            get { return _PP; }
            //Configured set to only set a value if it is greater than 0
            set 
            { 
                if (value > 0)
                {
                    _PP = value;
                }
                else
                {
                    throw new Exception("PowerPoint must be greater than 0");
                }
             }
        }
        
        public int Power { get; set; }
        public int Accuracy { get; set; }

        public override string ToString()
        {
            return $"===Ability Info===\nName: {Name}\nPP: {PP}\nPower: {Power}\nAccuracy: {Accuracy}";
        }
    }
}