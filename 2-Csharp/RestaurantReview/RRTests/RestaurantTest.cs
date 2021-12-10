using System;
using Xunit;
using RRModels;

namespace RRTests
{
    /// <summary>
    /// We will test the functionality of our Restaurant
    /// Usually you would want unit test for project such as
    ///     RestaurantModelTest - (for validation)
    ///     RestaurantBLTest - (for business logic)
    ///     and so on...
    /// </summary>
    public class RestaurantTest
    {
        /// <summary>
        /// This test will check if validation works in RestaurantModel
        /// </summary>
        [Fact] //Annotation to tell the compiler the method will be used for tests
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

        /// <summary>
        /// The test will check if validation will give an exception if gave wrong input
        /// </summary>
        /// <param name="input">what the validation will test</param>
        [Theory] //Theory lets you parameterized the method and to pass data
        [InlineData("121234Houston")]
        [InlineData("joefijslkfj234sdf")]
        public void CityShouldNotSetInvalidData(string input)
        {
            //Arrange
            Restaurant test = new Restaurant();

            //Act & Assert
            //Assert.Throw will expect the following block of code to give an exception
            Assert.Throws<Exception>(() => test.City = input);
        }
    }
}
