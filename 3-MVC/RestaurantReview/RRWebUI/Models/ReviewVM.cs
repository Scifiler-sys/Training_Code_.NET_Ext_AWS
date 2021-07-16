using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Models
{
    public class ReviewVM
    {
        public ReviewVM()
        { }

        public int Id { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }
}
