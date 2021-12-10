using System;
using RRModels;

namespace RRWebUI.Models
{
    public class ReviewVM
    {
        public ReviewVM()
        { }

        public ReviewVM(int p_restId)
        {
            RestaurantId = p_restId;
        }

        public ReviewVM(Review rev) : this(rev.RestaurantId)
        {
            Id = rev.Id;
            Rating = rev.Rating;
            Description = rev.Description;
        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
    }
}