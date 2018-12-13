using System.Linq;
using System.Threading.Tasks;
using Hogstorp.Core;
using Hogstorp.Core.Entities;
using Hogstorp.Core.Interfaces;
using Hogstorp.Web.ApiModels;
using Hogstorp.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Hogstorp.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class ToDoItemsController : Controller
    {
        private readonly IRepository _repository;

        public ToDoItemsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> List()
        {
            await DatabasePopulator.PopulateDatabaseAsync(_repository);
            var items = await _repository.ListAsync<ToDoItem>();
            return Ok(items.Select(ToDoItemDTO.FromToDoItem));
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = ToDoItemDTO.FromToDoItem(await _repository.GetByIdAsync<ToDoItem>(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItemDTO item)
        {
            var todoItem = new ToDoItem()
            {
                Title = item.Title,
                Description = item.Description
            };
            await _repository.AddAsync(todoItem);
            return Ok(ToDoItemDTO.FromToDoItem(todoItem));
        }

        [HttpPatch("{id:int}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var toDoItem = await _repository.GetByIdAsync<ToDoItem>(id);
            toDoItem.MarkComplete();
            await _repository.UpdateAsync(toDoItem);

            return Ok(ToDoItemDTO.FromToDoItem(toDoItem));
        }
    }
}
