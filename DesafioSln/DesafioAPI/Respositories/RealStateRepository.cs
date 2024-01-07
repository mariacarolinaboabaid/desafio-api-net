using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Context;
using DesafioAPI.Models;
using DesafioAPI.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioAPI.Respositories
{
    public class RealStateRepository : IRealStateRepository
    {
        // Injeção de dependência do banco de dados
        private readonly EstateAgencyContext _context;

        public RealStateRepository(EstateAgencyContext context)
        {
            _context = context;
        }

        // Listar todos ou listar com filtro
        public List<RealState>? GetAllOrByAttributes(string title = null, double? value = null, string neighborhood = null, int? bedroomQuantity = null, string businessType = null, string adress = null)
        {

            var properties = _context.Properties
            .ToList();

            if (!string.IsNullOrEmpty(title))
            {
                properties = properties.Where(x => x.Title.ToUpper().Contains(title.ToUpper())).ToList();
            }

            if (value.HasValue)
            {
                properties = properties.Where(x => x.Value == value).ToList();
            }

            if (!string.IsNullOrEmpty(neighborhood))
            {
                properties = properties.Where(x => x.Neighborhood.ToUpper().Contains(neighborhood.ToUpper())).ToList();
            }

            if (bedroomQuantity.HasValue)
            {
                properties = properties.Where(x => x.BedroomQuantity == bedroomQuantity).ToList();
            }

            if (!string.IsNullOrEmpty(businessType))
            {
                properties = properties.Where(x => x.BusinessType.ToUpper() == businessType.ToUpper()).ToList();
            }

            if (!string.IsNullOrEmpty(adress))
            {
                properties = properties.Where(x => x.Adress.ToUpper().Contains(adress.ToUpper())).ToList();
            }

            return properties;
        }

        // Listar por ID
        public RealState? GetById(int id)
        {
            return _context.Properties.FirstOrDefault(x => x.Id.Equals(id));
        }  

        // Adicionar
        public void Add(RealState realState)
        {
            _context.Properties.Add(realState);
            _context.SaveChanges();
        }

        // Atualizar
        public void Update(RealState realState)
        {
            _context.Properties.Update(realState);
            _context.SaveChanges();
        }
    }
}