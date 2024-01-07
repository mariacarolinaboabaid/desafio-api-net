using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Models;

namespace DesafioAPI.Respositories.Interfaces
{
    public interface IRealStateRepository
    {
        public List<RealState>? GetAllOrByAttributes(string title, double? value, string neighborhood, int? bedroomQuantity, string businessType, string adress);

        public RealState? GetById(int id);

        public void Add(RealState realState);

        public void Update(RealState realState);
    }
}