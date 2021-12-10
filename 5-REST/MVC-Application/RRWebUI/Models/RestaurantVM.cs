using System;
using System.ComponentModel.DataAnnotations;
using RRModels;

namespace RRWebUI.Models
{
    /*
        View Model contains the necessary information you want to present to the
        end user, or some infor that is vital to data processing (i.e. id)
    */
    public class RestaurantVM
    {
        public RestaurantVM()
        { }

        public RestaurantVM(Restaurant rest)
        {
            Id = rest.Id;
            City = rest.City;
            Name = rest.Name;
            State = rest.State;
        }

        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string State { get; set; }
        
    }
}