using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserWebApplication.Models;

namespace UserWebApplication.Repository
{
    public interface IUserRepository<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void Delete(T _object);
    }
        public class UserRepository : IUserRepository<User>
    {
        UserDbContext _dbContext;
        public UserRepository(UserDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<User> Create(User _object)
        {
            var obj = await _dbContext.Users.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(User _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return _dbContext.Users.Where(x => x.Active == 1).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public User GetById(int Id)
        {
            return _dbContext.Users.Where(x => x.Active == 1 && x.Id == Id).FirstOrDefault();
        }

        public void Update(User _object)
        {
            _dbContext.Users.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
