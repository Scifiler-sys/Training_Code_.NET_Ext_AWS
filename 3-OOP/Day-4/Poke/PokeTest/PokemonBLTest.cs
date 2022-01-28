using System;
using System.Collections.Generic;
using Moq;
using PokeBL;
using PokeDL;
using PokeModel;
using Xunit;

namespace Poke
{
    /// <summary>
    /// DON'T DO THIS FOR DEMO TOO COMPLEX
    /// </summary>
    public class PokemonBLTest
    {
        /// <summary>
        /// Checks GetAllPokemon does get all the pokemon given by our repository
        /// </summary>
        [Fact]
        public void Should_Get_All_Pokemon()
        {
            //Arrange
            string pokeName = "Pikachu";
            int pokeLevel = 10;
            Pokemon poke1 = new Pokemon
            {
                Name = pokeName,
                Level = pokeLevel
            };

            List<Pokemon> expectedListOfPoke = new List<Pokemon>();
            expectedListOfPoke.Add(poke1);

            //We are mocking one of the required dependency of pokemonBL which is the IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our irepository.GetAllPokemon() is called, it will always return the listOfPokemon we initiliazed earlier
            //We guarantee that the method will always work so in this way the only thing that can fail is our business layer (the one we are testing for)
            mockRepo.Setup(repo => repo.GetAllPokemon()).Returns(expectedListOfPoke);

            //We then pass our mocked repository to the constructor of our PokemonBL
            IPokemonBL pokeBL = new PokemonBL(mockRepo.Object, new Random());

            //Act
            List<Pokemon> actualListOfPoke = pokeBL.GetAllPokemon();

            //Assert
            Assert.Same(expectedListOfPoke, actualListOfPoke);
            Assert.Equal(actualListOfPoke[0].Name, pokeName);
            Assert.Equal(actualListOfPoke[0].Level, pokeLevel);
        }

        [Fact]
        public void Should_Add_Pokemon()
        {
            //Arrange
            string pokeName = "Bulbasaur";
            int pokelevel = 5;
            int randNumber = 2;
            //Setting pokemon with "randomized" stats
            Pokemon expectedPoke1 = new Pokemon()
            {
                Name = pokeName,
                Level = pokelevel
            };
            expectedPoke1.Health += randNumber;
            expectedPoke1.Attack += randNumber;
            expectedPoke1.Defense += randNumber;

            //Empty list to showcase we have an "empty" database at the beginning
            List<Pokemon> beforeActListOkPoke = new List<Pokemon>();

            //List after we "added" our pokemon
            List<Pokemon> expectedListOfPoke = new List<Pokemon>(){expectedPoke1}; 

            //Mocking all method dependencies
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            Mock<Random> mockRand = new Mock<Random>();

            //Rand.Next() method will always return a randNumber
            mockRand.Setup(rand => rand.Next()).Returns(randNumber);

            //Mock GetAllPokemon to give an empty list
            mockRepo.Setup(repo => repo.GetAllPokemon()).Returns(beforeActListOkPoke);
            //Mock AddPokemon to return our added pokemon
            mockRepo.Setup(repo => repo.AddPokemon(expectedPoke1)).Returns(expectedPoke1);
            
            IPokemonBL pokeBL = new PokemonBL(mockRepo.Object, mockRand.Object);
            
            //Act
            Pokemon actualPoke = pokeBL.AddPokemon(expectedPoke1);

            //Assert
            Assert.Same(expectedPoke1, actualPoke);
        }
    }
}