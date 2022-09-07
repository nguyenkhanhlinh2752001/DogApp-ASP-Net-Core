using DogApp.Database;
using DogApp.Interfaces;
using DogApp.Models;

namespace DogApp.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;

        }
        public bool Create(Category category)
        {
            _context.Categories.Add(category);
            return Save();
        }

        public bool Delete(Category category)
        {
            _context.Categories.Remove(category);
            return Save();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Category category)
        {
            _context.Categories.Update(category);
            return Save();
        }
    }
}
