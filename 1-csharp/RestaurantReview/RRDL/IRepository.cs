using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRDL
{
    /// <summary>
    /// Responsible for accessing our database (for this case our database for now will be a json file)
    /// </summary>
    public interface IRepository
    {
        Restaurant GetRestaurant();
        List<Restaurant> GetAllRestaurant();
        Restaurant AddRestaurant();
    }
}
