using System;
using RRModel;
using Xunit;

namespace RRTest
{
    public class RestaurantModelTest
    {
        /// <summary>
        /// This test will check if validation works in Restaurant Model
        /// It will input the right data and see if it persists
        /// </summary>
        [Fact]
        public void CityShouldSetValidData()
        {
            //Arrange
            Restaurant test = new Restaurant();
            string city = "Houston";

            //Act
            test.City = city;

            //Assert
            Assert.Equal(city, test.City);
        }

        /// <summary>
        /// The test will check if the validation works in Restaurant Model
        /// It will purposely put information that will be wrong and should throw an exception
        /// </summary>
        /// <param name="input"> This is the input that our test case will check in Act </param>
        [Theory]
        [InlineData("Houston123")]
        [InlineData("120983")]
        public void CityShouldNotSetInvalidData(string input)
        {
            //Arrange
            Restaurant test = new Restaurant();

            //Act
            Assert.Throws<Exception>(() => test.City = input);
        }
    }
}
