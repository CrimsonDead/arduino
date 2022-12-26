using dataLayer.Context;
using dataLayer.Models;

namespace dataLayer.Repositories
{
    public class SensorRepository : IRepository<Sensor>
    {
        private readonly ApplicationContext _context;

        public SensorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Sensor AddItem(Sensor item)
        {
            _context.Sensor.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Sensor Delete(Sensor item)
        {
            _context.Sensor.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Sensor GetItem(int id)
        {
            return _context.Sensor.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sensor> GetItems()
        {
            return _context.Sensor.ToList();
        }

        public Sensor Update(Sensor item)
        {
            _context.Sensor.Update(item);
            _context.SaveChanges();
            return _context.Sensor.First(s => s == item);
        }
    }
}
