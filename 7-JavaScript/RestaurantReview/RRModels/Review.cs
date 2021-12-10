using System;
using System.Collections.Generic;

namespace RRModel
{
    public class Review
    {
        public Review()
        { }

        public int Id { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public int RestaurantId { get; set; }
    }
}