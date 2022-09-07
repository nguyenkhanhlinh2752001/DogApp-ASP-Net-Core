using DogApp.Database;
using DogApp.Interfaces;
using DogApp.Models;

namespace DogApp.Repository
{
    public class OwnerRepository : IOwner
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
            
        }
        public bool Create(Owner owner)
        {
            _context.Owners.Add(owner);
            return Save();
        }

        public bool Delete(Owner owner)
        {
            _context.Owners.Remove(owner);
            return Save();
        }

        public bool Exists(int id)
        {
            return(_context.Owners.Any(x => x.Id == id));
        }

        public ICollection<Owner> Get()
        {
            return _context.Owners.ToList();
        }

        public Owner Get(int id)
        {
            return _context.Owners.FirstOrDefault(x => x.Id == id);
        }

        

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Owner owner)
        {
            _context.Owners.Update(owner);
            return Save();
        }
    }
}
