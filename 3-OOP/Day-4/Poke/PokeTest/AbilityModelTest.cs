using System;
using PokeModel;
using Xunit;

namespace PokeTest
{
    public class AbilityModelTest
    {
        /// <summary>
        /// Checks validation for PP property for correct data
        /// </summary>
        //Data annotation that tells the compiler that this method will do something more than what a regular method would do
        //In this case, [Fact] tells that this method is one unit test
        [Fact] 
        public void PP_Should_Set_ValidData()
        {
            //Arrange
            Ability abi = new Ability();
            int PPValue = 20;

            //Act
            abi.PP = PPValue;

            //Assert
            Assert.NotNull(abi.PP);
            Assert.Equal(PPValue, abi.PP);
        }

        /// <summary>
        /// Checks validation for PP property with incorrect data
        /// </summary>
        /// [Theory] changes the unit test to be parameterized and run that unit test multiple times with different data each time
        [Theory]
        [InlineData(-10)]
        [InlineData(-100)]
        [InlineData(-19284)]
        public void PP_Should_Fail_Set_InvalidData(int p_PPValue)
        {
            //Arrange
            Ability abi = new Ability();

            //Act & Assert
            Assert.Throws<Exception>(() => abi.PP = p_PPValue);

        }
    }
}
