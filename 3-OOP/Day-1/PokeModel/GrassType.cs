namespace PokeModel
{
    /*
        - Inheritance is denoted by ":" syntax and anything after the colon is what the class will inherit
        - Once you inherit something, anything from that class will be pass down to GrassType
        - There are many exceptions to this rule such as private class members won't get pass down as well
          as sealed methods
    */
    public class GrassType : Pokemon
    {
        public GrassType()
        {
            this.Name = "Bulbasaur";
            this.Attack = 49;
            this.Defense = 49;
            this.Health = 45;
        }

        //Example of Method Overriding
        //It will override the implementation details from the base class
        //You must use the override keyword
        //Special case that grass type in general have a higher chance to have more defense
        public override int DefendMove()
        {
            return this.Defense + this._rand.Next(5,10);
        }

        //Example of Method Overloading
        //Same name but different paremeter method that have a slightly different implementation detail
        //In this way even the method have multiple forms of functionality (like the general definition of what polymorphism is)
        //Note: parameters are a great way (if not the best way) to pass additional data to a method that it needs to use
        public int DefendMove(int p_increase)
        {
            return this.Defense + this._rand.Next(5,10) + p_increase;
        }
    }
}