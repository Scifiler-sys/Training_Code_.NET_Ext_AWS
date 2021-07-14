using System;
using System.Collections.Generic;
using RRModels;

namespace RRBL
{
    public interface IReview
    {
        Review AddReview(Restaurant p_rest, Review p_rev);
        Tuple<List<Review>, double> GetReviews(Restaurant p_rest);
    }
}