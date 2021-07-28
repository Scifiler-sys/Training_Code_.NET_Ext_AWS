using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RRBL;
using RRModels;
using RRWebUI.Controllers;
using RRWebUI.Models;
using Xunit;

namespace RRTests
{
    public class RestaurantControllerTest
    {
        [Fact]
        public void RestaurantControllerIndexShouldReturnRestaurantList()
        {
            //Arrange
            var mockBL = new Mock<IRestaurant>();
            mockBL.Setup(rest => rest.GetAllRestaurantAsync()).Returns
            (
                new List<Restaurant>
                {
                    new Restaurant("Stephen's Rest", "Houston", "Texas"),
                    new Restaurant("Crawfish's Rest", "Dallas", "Texas")
                }
            );
            var restControl = new RestaurantController(mockBL.Object);

            //Act
            var result = restControl.Index(); //Need to add ef.design nuget to get it to work

            //Assert
            //We check if the result is a type of ViewResult
            var viewResult = Assert.IsType<ViewResult>(result); 

            //We check if the ViewResult returns a list (specifically the list we created at the above)
            var model = Assert.IsAssignableFrom<IEnumerable<RestaurantVM>>(viewResult.ViewData.Model);

            //We check if the list has a count of 2 (since we only created two entries)
            //You can be even more detail and see if each of those two entries actually carry the values we set for them
            Assert.Equal(2, model.Count());
        }
    }
}