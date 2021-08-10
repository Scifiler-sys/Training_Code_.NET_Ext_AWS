using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RRModel
{
    public class Restaurant
    {
        private string _city;

        public Restaurant()
        {
            Name = "Default";
        }

        public Restaurant(string p_name)
        {
            Name = p_name;
        }
        public int Id { get; set; }
        public string Name { get; set;}
        public string City {

            get
            {
                return _city;
            } 

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                {
                    //This will throw an exception whenever you try to store the city property with numbers
                    throw new Exception("City can only hold letters!");
                }

                _city = value;
            }

        }
        public string State { get; set; }

        public double Revenue { get; set; }

        public List<Review> Reviews { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, City: {City}, State: {State}";
        }
    }
}
