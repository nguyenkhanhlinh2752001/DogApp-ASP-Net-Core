using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApp.Models;

namespace DogApp.Interfaces
{
    public interface ICategory
    {
        ICollection<Category> Get();
        Category Get(int id);
        bool Exists(int id);
        bool Save();
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(Category category);
        
    }
}
