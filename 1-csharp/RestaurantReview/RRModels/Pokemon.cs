using System;
using System.Text.RegularExpressions;

namespace RRModels
{
    public class Pokemon
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                //This checks the string if it has anything but letters
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$"))
                    throw new Exception("Name can only hold letters!");
                    
                _name = value; 
            }
        }

        public string Type { get; set; }

        public int Health { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        
    }
}