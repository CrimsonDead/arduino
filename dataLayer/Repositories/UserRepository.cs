using dataLayer.Context;
using dataLayer.Models;

namespace dataLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User AddItem(User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
            return item;
        }

        public User Delete(User item)
        {
            _context.User.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public User GetByUserCredentials(string userName, string password)
        {
            var item = _context.User.FirstOrDefault(u => 
                u.UserName == userName && 
                u.Password == password);
            return item;
        }

        public User GetItem(int id)
        {
            return _context.User.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<User> GetItems()
        {
            return _context.User.ToList();
        }

        public User Update(User item)
        {
            _context.User.Update(item);
            _context.SaveChanges();
            return _context.User.First(u => u == item);
        }
    }
}