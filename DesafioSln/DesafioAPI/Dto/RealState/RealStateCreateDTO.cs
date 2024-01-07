using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Dto.RealState
{
    public class RealStateCreateDTO
    {
        public string Title { get; set; }

        public double Value { get; set;}

        public string Neighborhood { get; set; }

        public int BedroomQuantity { get; set; }

        public string BusinessType { get; set; }

        public string Adress { get; set; }

    }
}

