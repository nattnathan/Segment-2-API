using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GeneralController<TEntity> : ControllerBase
    {
        private readonly IGeneralRepository<TEntity> _repository;

        public GeneralController(IGeneralRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entity = _repository.GetAll();
            if (!entity.Any())
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var entity = _repository.GetByGuid(guid);
            if (entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Create(TEntity entity)
        {
            var createEntity = _repository.Create(entity);
            return Ok(createEntity);
        }

        [HttpPut]
        public IActionResult Update(TEntity entity)
        {
            var isUpdate = _repository.Update(entity);
            if (!isUpdate)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var isDelete = _repository.Delete(guid);
            if (!isDelete)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
