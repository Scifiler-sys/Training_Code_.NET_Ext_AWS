using System.Collections.Generic;
using Moq;
using PokeBL;
using PokeDL;
using PokeModel;
using Xunit;

namespace PokeTest
{
    public class PokemonBLTest
    {
        [Fact]
        public void Should_Get_All_Pokemon()
        {
            //Arrange
            string pokeName = "Pikachu";
            int pokeLevel = 5;
            Pokemon poke = new Pokemon()
            {
                Name = pokeName,
                Level = pokeLevel
            };

            List<Pokemon> expectedListOfPoke = new List<Pokemon>();
            expectedListOfPoke.Add(poke);

            //We are mocking one of the required dependencies of PokemonBL which is IRepository
            Mock<IRepository<Pokemon>> mockRepo = new Mock<IRepository<Pokemon>>();

            //We change that if our IRepository.GetAllPokemon() is called, it will always return our expectedListOfPoke
            //In this way, we guaranteed that our dependency will always work so if something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetAll()).Returns(expectedListOfPoke);

            //We passed in the mock version of IRepository
            IPokemonBL pokeBL = new PokemonBL(mockRepo.Object);

            //Act
            List<Pokemon> actualListOfPoke = pokeBL.GetAllPokemon();

            //Assert
            Assert.Same(expectedListOfPoke, actualListOfPoke); //Checks if both list are the same thing
            Assert.Equal(pokeName, actualListOfPoke[0].Name); //Checks the first element of actualListOfPoke to have the same name
            Assert.Equal(pokeLevel, actualListOfPoke[0].Level); //Checks the first element of actualListOfPoke to have teh same level
        }
    }
}