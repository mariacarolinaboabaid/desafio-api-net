using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Models;

namespace DesafioAPI.Respositories.Interfaces
{
    public interface IRealStateImageRepository
    {
        public RealStateImage? GetById(int id);

        public List<RealStateImage> GetAllByRealStateId(int realStateId);

         public void Add(RealStateImage realStateImage);

        public void Update(RealStateImage realStateImage);
    }
}