using DogApp.Models;

namespace DogApp.Interfaces
{
    public interface IOwner
    {
        ICollection<Owner> Get();
        Owner Get(int id);
        bool Exists(int id);
        bool Save();
        bool Create(Owner owner);
        bool Update(Owner owner);
        bool Delete(Owner owner);
        
    }
}
