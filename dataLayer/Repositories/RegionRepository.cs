using dataLayer.Context;
using dataLayer.Models;

namespace dataLayer.Repositories
{
    public class RegionRepository : IRepository<Region>
    {
        private readonly ApplicationContext _context;

        public RegionRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Region AddItem(Region item)
        {
            _context.Region.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Region Delete(Region item)
        {
            _context.Region.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Region GetItem(int id)
        {
            return _context.Region.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Region> GetItems()
        {
            return _context.Region.ToList();
        }

        public Region Update(Region item)
        {
            _context.Region.Update(item);
            _context.SaveChanges();
            return _context.Region.First(r => r == item);
        }
    }
}
