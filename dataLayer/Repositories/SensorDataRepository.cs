using dataLayer.Context;
using dataLayer.Models;

namespace dataLayer.Repositories
{
    public class SensorDataRepository : IRepository<SensorData>
    {
        private readonly ApplicationContext _context;

        public SensorDataRepository(ApplicationContext context)
        {
            _context = context;
        }
        public SensorData AddItem(SensorData item)
        {
            _context.SensorData.Add(item);
            _context.SaveChanges();
            return item;
        }

        public SensorData Delete(SensorData item)
        {
            _context.SensorData.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public SensorData GetItem(int id)
        {
            return _context.SensorData.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SensorData> GetItems()
        {
            return _context.SensorData.ToList();
        }

        public SensorData Update(SensorData item)
        {
            _context.SensorData.Update(item);
            _context.SaveChanges();
            return _context.SensorData.First(s => s == item);
        }
    }
}