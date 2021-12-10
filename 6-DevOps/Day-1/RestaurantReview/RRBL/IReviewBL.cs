using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRBL
{
    public interface IReviewBL
    {
        /// <summary>
        /// It will add a review and attach it to a restaurant
        /// </summary>
        /// <param name="p_rest">Passes the restaurant we will attach the review to</param>
        /// <param name="p_rev">The review we will add to the restaurant</param>
        /// <returns></returns>
        Review AddReview(Restaurant p_rest, Review p_rev);
        /// <summary>
        /// It will get all the reviews
        /// </summary>
        /// <param name="p_rest">Gets the reviews that is attached to that restaurant</param>
        /// <returns></returns>
        List<Review> GetReviews(Restaurant p_rest);
    }
}
