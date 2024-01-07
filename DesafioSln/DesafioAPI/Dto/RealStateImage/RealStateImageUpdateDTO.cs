using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Dto.RealStateImage
{
    public class RealStateImageUpdateDTO
    {
        public int RealStateId { get; set; }
        
        public string ImageUrl { get; set; }
    }
}