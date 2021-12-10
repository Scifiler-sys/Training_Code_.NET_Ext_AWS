using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RRModels
{
    public class Restaurant
    {
        private string _city;

        public Restaurant()
        {
        }
        public Restaurant(string p_name, string p_city, string p_state)
        {
            Name = p_name;
            City = p_city;
            State = p_state;
        }

        public Restaurant(int p_id, string p_name, string p_city, string p_state) : this(p_name, p_city, p_state)
        {
            Id = p_id;
        }

        public string City
        {
            get { return _city; }
            set 
            { 
                if(!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                    throw new Exception("City cannot have numbers!");
                _city = value; 
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string State { get; set; }

        public List<Review> Reviews { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nLocation: {City}, {State}";
        }
        
    }
}