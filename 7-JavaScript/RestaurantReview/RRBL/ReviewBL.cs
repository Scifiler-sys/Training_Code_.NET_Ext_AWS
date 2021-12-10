using RRDL;
using RRModel;
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

        public async Task<Review> AddReview(Restaurant p_rest, Review p_rev)
        {
            if (await _repo.GetRestaurantAsync(p_rest) == null)
            {
                throw new Exception("The restaurant does not exist!");
            }

            await _repo.AddReviewAsync(p_rest, p_rev);

            return p_rev;
        }

        public async Task<List<Review>> GetReviews(Restaurant p_rest)
        {
            if (await _repo.GetRestaurantAsync(p_rest) == null)
            {
                throw new Exception("The restaurant does not exist!");
            }

            return await _repo.GetReviewsAsync(p_rest);
        }
    }
}
