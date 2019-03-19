using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Hogstorp.Core;
using Hogstorp.Core.Entities;
using Hogstorp.Core.Interfaces;
using Hogstorp.Web.ApiModels;
using Hogstorp.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hogstorp.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class PlayerController : Controller
    {
        private readonly IRepository _repository;

        public PlayerController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> List()
        {
            await DatabasePopulator.PopulateDatabaseAsync(_repository);
            var items = await _repository.ListAsync<Player>(x => x.Include(p => p.PlayerTrainings));
            return Ok(items.Select(PlayerDto.FromToDoItem));
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = PlayerDto.FromToDoItem(await _repository.FindAsync<Player>(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        //todo
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

        //todo - add to training kanske.
        [HttpPatch("{id:int}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var toDoItem = await _repository.FindAsync<ToDoItem>(id);
            toDoItem.MarkComplete();
            await _repository.UpdateAsync(toDoItem);

            return Ok(ToDoItemDTO.FromToDoItem(toDoItem));
        }
    }
}
