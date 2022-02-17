namespace AsyncFunction
{
    /*

        In the context of cooking something
        As you know with cooking shows, to expedite the process of getting a finish product they would cook separate things at the same time, they are essentially doing asynchrnous cooking
        We can do the same thing with code to also try and be efficient by running things at the same time
    */
    public class Asynchronous
    {
        //This usually takes a really long time to finish and is usually done first
        public async Task<string> CookingRice()
        {
            Console.WriteLine("Started cooking Rice...");
            await Task.Delay(5000); //This line just stops the program for 5000 milliseconds
            return "Finished cooking rice";
        }

        //Usually in cooking, you cook the meat first
        //We want both the rice and to cook at the same time to be efficient
        public async Task<string> CookingMeat()
        {
            Console.WriteLine("Started cooking Meat...");
            await Task.Delay(3000);
            return "Finished cooking meat";
        }

        //You cook the veggies after you only finish cooking the meat
        //We want to only cook the veggies after finish cooking the meat
        public async Task<string> CookingVeggies()
        {
            Console.WriteLine("Started cooking Veggies...");
            await Task.Delay(1000);
            return "Finished cooking veggies";
        }

        public async Task<string> CookMeatThenVeggies()
        {
            Console.WriteLine(await CookingMeat());
            Console.WriteLine(await CookingVeggies());
            return "Finished cooking main course";
        }
    }
}