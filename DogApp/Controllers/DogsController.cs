using DogApp.Interfaces;
using DogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController:Controller
    {
        private readonly IDog _idog;
        public DogsController(IDog idog)
        {
            _idog = idog;          
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_idog.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            return Ok(_idog.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Dog dog){
            var newObj = new Dog();
            newObj.Name = dog.Name;
            newObj.Description = dog.Description;
            newObj.CategoryId = dog.CategoryId;
            newObj.OwnerId = dog.OwnerId;
            return Ok(_idog.Create(newObj));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Dog dog){
            var updateObj = _idog.Get(id);
            updateObj.Name=dog.Name;
            updateObj.Description=dog.Description;
            updateObj.CategoryId=dog.CategoryId;
            updateObj.OwnerId=dog.OwnerId;
            return Ok(_idog.Update(updateObj));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var deleteObj = _idog.Get(id);
            return Ok(_idog.Delete(deleteObj));
        }

        [HttpGet("category/{id}")]
        public IActionResult GetDogsByCategory(int id){
            return Ok(_idog.GetDogsByCategory(id));
        }

        [HttpGet("owner/{id}")]
        public IActionResult GetDogsByOwner(int id){
            return Ok(_idog.GetDogsByOwner(id));
        }

    }
}
