using RRModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Models
{
    /*
     * Holds the data structure of the models that you will want to use in your views
     */
    public class RestaurantVM
    {
        public RestaurantVM()
        { }

        public RestaurantVM(Restaurant p_rest)
        {
            Id = p_rest.Id;
            City = p_rest.City;
            Name = p_rest.Name;
            State = p_rest.State;
            Revenue = p_rest.Revenue;
        }

        public int Id { get; set; }

        //This is a data annotation that helps with validation
        [Required]
        public string City { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        [Required]

        public double Revenue { get; set; }
    }
}
