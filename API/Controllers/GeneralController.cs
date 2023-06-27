/*using API.Contracts;
using API.Models;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class GeneralController<TEntityReposity, TEntity> : ControllerBase
        where TEntityReposity : IGeneralRepository<TEntity>
        where TEntity : class
    {
        protected readonly TEntityReposity _repository;

        public GeneralController(TEntityReposity repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entity = _repository.GetAll();
            if (!entity.Any())
            {
                return NotFound(new ResponseHandler<TEntity>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"

                });
            }

            return Ok(new ResponseHandler<IEnumerable<TEntity>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "All Data Found",
                Data = entity
            });
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var entity = _repository.GetByGuid(guid);
            if (entity is null)
            {
                return NotFound(new ResponseHandler<TEntity>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data By Guid Not Found"
                });
            }

            return Ok(new ResponseHandler<TEntity>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data By Guid Found",
                Data = entity
            });
        }

        [HttpPost]
        public IActionResult Create(TEntity entity)
        {
            var createEntity = _repository.Create(entity);
            return Ok(new ResponseHandler<TEntity>
            {
                Code = StatusCodes.Status201Created,
                Status = HttpStatusCode.Created.ToString(),
                Message = "Data Has Been Created",
                Data = createEntity
            });
        }

        [HttpPut]
        public IActionResult Update(TEntity entity)
        {
            var getGuid = (Guid)typeof(TEntity).GetProperty("Guid")!.GetValue(entity)!;
            var isFound = _repository.IsExist(getGuid);

            if (isFound is false)
            {
                return NotFound(new ResponseHandler<TEntity>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id Not Found"
                });
            }
            var isUpdate = _repository.Update(entity);
            if (!isUpdate)
            {
                return BadRequest(new ResponseHandler<TEntity>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }

            return Ok(new ResponseHandler<TEntity>
            {
                Code = StatusCodes.Status202Accepted,
                Status = HttpStatusCode.Accepted.ToString(),
                Message = "Data Has Been Update",
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var isFound = _repository.IsExist(guid);

            if (isFound is false)
            {
                return NotFound(new ResponseHandler<TEntity>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }

            var isDelete = _repository.Delete(guid);
            if (!isDelete)
            {
                return BadRequest(new ResponseHandler<TEntity>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new ResponseHandler<TEntity>
            {
                Code = StatusCodes.Status202Accepted,
                Status = HttpStatusCode.Accepted.ToString(),
                Message = "Data Has Been Delete",
            });
        }

    }
}
*/