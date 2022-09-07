using DogApp.Database;
using DogApp.Interfaces;
using DogApp.Models;

namespace DogApp.Repository
{
    public class DogRepository : IDog
    {
        private readonly DataContext _context;
        public DogRepository(DataContext context)
        {
            _context = context;         
        }

        public bool Create(Dog dog)
        {
            _context.Dogs.Add(dog);
            return Save();
        }

        public bool Delete(Dog dog)
        {
            _context.Dogs.Remove(dog);
            return Save();
        }

        public bool Exists(int id)
        {
            return _context.Dogs.Any(d => d.Id == id);
        }

        public ICollection<Dog> Get()
        {
            return _context.Dogs.ToList();
        }

        public Dog Get(int id)
        {
            return _context.Dogs.FirstOrDefault(d => d.Id == id);
        }

        public ICollection<Dog> GetDogsByCategory(int categoryId)
        {
            return _context.Dogs.Where(d => d.CategoryId == categoryId).ToList();
        }

        public ICollection<Dog> GetDogsByOwner(int ownerId)
        {
            return _context.Dogs.Where(d => d.OwnerId == ownerId).ToList();
        }
        public string GetOwnerNameByDogId(int id)
        {
            return _context.Dogs.Where(x => x.Id == id).Select(x => x.Owner.Name).FirstOrDefault();
        }
        public string GetCategoryNameByDogId(int dogId)
        {
            return _context.Dogs.Where(d => d.Id == dogId).Select(d => d.Category.Name).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Dog dog)
        {
            _context.Dogs.Update(dog);
            return Save();
        }
    }
}
