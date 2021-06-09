using System;
using System.Collections.Generic;

/*
    This RRModels namespace is responsible for holding the data structure of our application
*/
namespace RRModels
{
    public class Restaurant
    {
        private string _city;

        public Restaurant()
        { }

        //The benefit of this is adding restrictions to how you want this field to be set.
        //You can also manipulate how this field will be get
        public string City
        {
            get { return $"This restaurant is at {_city}"; }
            set { _city = value.ToLower(); }
        }
        
        //You can just create stand alone properties
        public string State { get; set; }

        public int Id { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
