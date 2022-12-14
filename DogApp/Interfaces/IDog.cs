using DogApp.Models;

namespace DogApp.Interfaces
{
    public interface IDog
    {
        ICollection<Dog> Get();
        Dog Get(int id);
        bool Exists(int id);
        bool Save();
        bool Create(Dog dog);
        bool Update(Dog dog);
        bool Delete(Dog dog);

        ICollection<Dog> GetDogsByCategory(int categoryId);
        ICollection<Dog> GetDogsByOwner(int ownerId);
        string GetOwnerNameByDogId(int id);
        string GetCategoryNameByDogId(int id);
    }
}
