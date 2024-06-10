using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.Entities;
using SalesAPI.Repositories;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorytRepository _repository;

        public CategoriesController(ICategorytRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _repository.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _repository.GetById(id);
                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound(ModelState);
                }

                var data = await _repository.Create(model);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, Category model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound(ModelState);
                }

                var data = await _repository.GetById(id);
                if (data == null)
                {
                    return NotFound($"{model.Id} is not found!");
                }

                data.Name = model.Name;
                data.Description = model.Description;

                var result = await _repository.Update(data);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
