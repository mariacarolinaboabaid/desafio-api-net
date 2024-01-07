using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Context;
using DesafioAPI.Models;
using DesafioAPI.Respositories.Interfaces;

namespace DesafioAPI.Respositories
{
    public class RealStateImageRepository : IRealStateImageRepository
    {
         // Injeção de dependência do banco de dados
        private readonly EstateAgencyContext _context;

        public RealStateImageRepository(EstateAgencyContext context)
        {
            _context = context;
        }

        // Listar por ID
        public RealStateImage? GetById(int id)
        {
            return _context.Photos.FirstOrDefault(x => x.Id.Equals(id));
        }

        // Listar todos por RealStateId
        public List<RealStateImage> GetAllByRealStateId(int realStateId)
        {
            return _context.Photos
            .Where(x => x.RealStateId == realStateId)
            .ToList();
 
        }

        // Adicionar
        public void Add(RealStateImage realStateImage)
        {
            _context.Photos.Add(realStateImage);
            _context.SaveChanges();
        }

        // Atualizar
        public void Update(RealStateImage realStateImage)
        {
             _context.Photos.Update(realStateImage);
            _context.SaveChanges();
        }
    }
}