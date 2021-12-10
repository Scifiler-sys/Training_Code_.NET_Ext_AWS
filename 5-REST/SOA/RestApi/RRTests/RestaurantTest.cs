using System;
using RRModels;
using Xunit;

namespace RRTests
{
    public class RestaurantTest
    {
        [Fact] //denotes a parameterless unit test
        public void CityShouldSetValidData()
        {
            //Arrange
            string city = "Houston";
            Restaurant test = new Restaurant();
            
            //Act
            test.City = city;

            //Assert
            Assert.Equal(city, test.City);

        }

        [Theory] //denotes a parameterized test
        [InlineData("123456789")] //We can use InlineData to pass data in the parameter
        [InlineData("Texas12")]
        [InlineData("Texas43")]
        public void CityShouldNotSetInvalidData(string input)
        {
            //Arrange
            Restaurant test = new Restaurant();

            //Act & Assert
            Assert.Throws<Exception>(() => test.City = input); //Checks if the code will throw an exception
        }
    }
}
