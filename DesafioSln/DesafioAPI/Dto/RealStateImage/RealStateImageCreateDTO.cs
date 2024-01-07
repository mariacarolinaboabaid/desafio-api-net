using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Dto.RealStateImage
{
    public class RealStateImageCreateDTO
    {
        public int RealStateId { get; set; }
        
        public string ImageUrl { get; set; }
    }
}