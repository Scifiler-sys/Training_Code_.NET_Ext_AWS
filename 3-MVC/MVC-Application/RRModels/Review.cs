using System;

namespace RRModels
{
    public class Review
    {

        public Review()
        { }

        public Review(int p_rating, string p_desc)
        {
            Rating = p_rating;
            Description = p_desc;
        }
        public Review(int p_rating, string p_desc, int p_restId)
        {
            Rating = p_rating;
            Description = p_desc;
            RestaurantId = p_restId;
        }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set 
            { 
                if(_rating < 0)
                    throw new Exception("Rating should be greater than zero");
                
                _rating = value;
            }
        }

        public string Description { get; set; }

        public int RestaurantId { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Rating: {Rating}\nDescription: {Description}";
        }
    }
}
