using RRDL;
using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRBL
{
    public class ReviewBL : IReviewBL
    {
        private IRepository _repo;

        public ReviewBL(IRepository p_repo)
        {
            p_repo = _repo;
        }

        public Review AddReview(Restaurant p_rest, Review p_rev)
        {
            if (_repo.GetRestaurant(p_rest) == null)
            {
                throw new Exception("The restaurant does not exist!");
            }

            _repo.AddReview(p_rest, p_rev);

            return p_rev;
        }

        public List<Review> GetReviews(Restaurant p_rest)
        {
            if (_repo.GetRestaurant(p_rest) == null)
            {
                throw new Exception("The restaurant does not exist!");
            }

            return _repo.GetReviews(p_rest);
        }
    }
}
