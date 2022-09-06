using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApp.Interfaces;
using DogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CategoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: Controller
    {
        private readonly ICategory _icategory;
        public CategoryController(ICategory icategory)
        {
            _icategory = icategory;          
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_icategory.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            return Ok(_icategory.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category){
            var newObj = new Category();
            newObj.Name = category.Name;
            return Ok(_icategory.Create(newObj));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category){
            var updateObj = _icategory.Get(id);
            updateObj.Name=category.Name;
            return Ok(_icategory.Update(updateObj));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var deleteObj = _icategory.Get(id);
            return Ok(_icategory.Delete(deleteObj));
        }

        [HttpGet("dog/{dogId}")]
        public IActionResult GetCategoryNameByDogId(int dogId){
            return Ok(_icategory.GetCategoryNameByDogId(dogId));
        }
    }
}
