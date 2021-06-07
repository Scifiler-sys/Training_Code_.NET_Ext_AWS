using System;

/*
    This RRModels namespace is responsible for holding the data structure of our application
*/
namespace RRModels
{
    public class Restaurant
    {
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        
    }
}
