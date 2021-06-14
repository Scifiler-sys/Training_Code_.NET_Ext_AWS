using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            set 
            { 
                //This checks the string if it has anything but letters
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                    throw new Exception("City can only hold letters!");
                    
                _city = value;
            }
        }
        
        //You can just create stand alone properties
        public string State { get; set; }

        public string Name { get; set; }

        public List<Review> Reviews { get; set; }

        public bool Equals(Restaurant p_rest)
        {
            return (p_rest.State == this.State && p_rest.City == this.City && p_rest.Name == this.Name);
        }
    }
}
