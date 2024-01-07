using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Models;

namespace DesafioAPI.Respositories.Interfaces
{
    public interface IUserRepository
    {
        public List<User>? GetAllOrByAttributes(string name, string email, string telephone);

        public User? GetById(int id);

        public void Add(User user);

        public void Update(User user);
    }
}