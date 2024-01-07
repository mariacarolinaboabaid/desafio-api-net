using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Context;
using DesafioAPI.Models;
using DesafioAPI.Respositories.Interfaces;

namespace DesafioAPI.Respositories
{
    public class UserRepository : IUserRepository
    {
        // Injeção de dependência do banco de dados
        private readonly EstateAgencyContext _context;

        public UserRepository(EstateAgencyContext context)
        {
            _context = context;
        }

        // Listar todos ou listar com filtro
        public List<User> GetAllOrByAttributes(string name = null, string email = null, string telephone = null)
        {

            var users = _context.Users.ToList();

            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(email))
            {
                users = users.Where(x => x.Email.ToUpper().Contains(email.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(telephone))
            {
                users = users.Where(x => x.Telephone == telephone).ToList();
            }

            return users;
        }

        // Listar por ID
        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id.Equals(id));
        }  

        // Adicionar
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Atualizar
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}