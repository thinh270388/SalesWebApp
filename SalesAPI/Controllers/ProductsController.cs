using Microsoft.AspNetCore.Mvc;
using SalesAPI.Entities;
using SalesAPI.Repositories;
using SalesModels;
using SalesModels.Enums;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var results = await _repository.GetAll();
                return Ok(results.Select(x => new ProductDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    InputPrice = x.InputPrice,
                    OutputPrice = x.OutputPrice,
                    Quantity = x.Quantity,
                    Status = x.Status,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name
                }).ToList());
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
                return data == null ? NotFound() : Ok(new ProductDto()
                {
                    Id = data.Id,
                    Name = data.Name,
                    InputPrice = data.InputPrice,
                    OutputPrice = data.OutputPrice,
                    Quantity = data.Quantity,
                    Description = data.Description,
                    Status = data.Status,
                    CategoryId = data.CategoryId,
                    CategoryName = data.Category!.Name
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestCreate request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NotFound(ModelState);
                }

                var data = await _repository.Create(new Product()
                {
                    Id = request.Id,
                    Name = request.Name,
                    InputPrice = request.InputPrice,
                    OutputPrice = request.OutputPrice,
                    Quantity = request.Quantity,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    Status = StatusProduct.Online
                });
                return Ok(new ProductDto()
                {
                    Id = data.Id,
                    Name = data.Name,
                    InputPrice = data.InputPrice,
                    OutputPrice = data.OutputPrice,
                    Quantity = data.Quantity,
                    Status = data.Status,
                    Description = data.Description,
                    CategoryId = data.CategoryId,
                    CategoryName = data.Category == null ? "N/A" : data.Category.Name
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, ProductRequestUpdate request)
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
                    return NotFound($"{id} is not found!");
                }

                data.Name = request.Name;
                data.InputPrice = request.InputPrice;
                data.OutputPrice = request.OutputPrice;
                data.Quantity = request.Quantity;
                data.Description = request.Description;
                data.Status = request.Status;
                data.CategoryId = request.CategoryId;

                var result = await _repository.Update(data);
                return Ok(new ProductDto()
                {
                    Id = data.Id,
                    Name = data.Name,
                    InputPrice = data.InputPrice,
                    OutputPrice = data.OutputPrice,
                    Quantity = data.Quantity,
                    Description = data.Description,
                    Status  = data.Status,
                    CategoryId = data.CategoryId,
                    CategoryName = data.Category == null ? "N/A" : data.Category.Name
                });
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
