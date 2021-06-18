using System;

namespace RRModels
{
    public class Review
    {
        public Review()
        { }

        public int Id { get; set; }
        public double rating { get; set; }
        public string Description { get; set; }
    }
}