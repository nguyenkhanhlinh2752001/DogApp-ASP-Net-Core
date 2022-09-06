using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApp.Interfaces;
using DogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController:Controller
    {
        private readonly IOwner _iowner;
        public OwnerController(IOwner iowner)
        {
            _iowner = iowner;         
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_iowner.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            return Ok(_iowner.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Owner owner){
            var newObj = new Owner();
            newObj.Name = owner.Name;
            newObj.Address = owner.Address;
            return Ok(_iowner.Create(newObj));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Owner owner){
            var updateObj = _iowner.Get(id);
            updateObj.Name=owner.Name;
            updateObj.Address=owner.Address;
            return Ok(_iowner.Update(updateObj));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var deleteObj = _iowner.Get(id);
            return Ok(_iowner.Delete(deleteObj));
        }
        
    }
}
