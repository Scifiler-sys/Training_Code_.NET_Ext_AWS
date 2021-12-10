using System;
using System.Collections.Generic;
using Moq;
using RRBL;
using RRDL;
using RRModels;
using Xunit;

namespace RRTests
{
    public class ReviewBLTest
    {
        [Theory]
        [InlineData(4,5)]
        [InlineData(3,5)]
        public void GetReviewsShouldReturnAverage(int x, int y)
        {
            //Arrange
            //We need to create a mock repo because we want to ensure that 
            //the repo is not the problem of this unit test and only the BL
            //The Mock class is available from the Moq package and it is for mocking data
            var mockRepo = new Mock<IRepository>();
            double avg = (x+y)/2.0; //find the average of the two things we passed
            
            //We mock the GetReviews method from the IRepository to gaurantee to give these two reviews we have stated
            mockRepo.Setup(repo => repo.GetReviews(It.IsAny<Restaurant>())).Returns
            (
                new List<Review>()
                {
                    new Review(x, "Really good"),
                    new Review(y, "To die for")
                }
            );
            
            //We passed the mock object
            var reviewBL = new ReviewBL(mockRepo.Object);

            //Act
            var result = reviewBL.GetReviews(new Restaurant());

            //Assert
            Assert.Equal(avg, result.Item2);
        }
    }
}