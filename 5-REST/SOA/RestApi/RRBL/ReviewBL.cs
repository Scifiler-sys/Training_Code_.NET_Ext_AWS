using System;
using System.Collections.Generic;
using RRDL;
using RRModels;

namespace RRBL
{
    public class ReviewBL : IReview
    {
        private IRepository _repo;
        public ReviewBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public Review AddReview(Restaurant p_rest, Review p_rev)
        {
            _repo.AddReview(p_rest, p_rev);
            return p_rev;
        }

        public Tuple<List<Review>, double> GetReviews(Restaurant p_rest)
        {
            double averageRating = 0;
            List<Review> reviews = _repo.GetReviews(p_rest);

            if (reviews.Count > 0)
            {
                reviews.ForEach(
                    rev => averageRating += rev.Rating
                );

                averageRating = averageRating / reviews.Count;
            }

            return new Tuple<List<Review>, double>(reviews, averageRating);
        }
    }
}