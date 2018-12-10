using System.Collections.Generic;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core
{
    public static class DatabasePopulator
    {
        public static async Task<int> PopulateDatabaseAsync(IRepository todoRepository)
        {
            var toDoItems = await todoRepository.ListAsync<ToDoItem>();
            if (toDoItems.Any()) return 0;
            var tasks = new List<Task>();
            tasks.Add(todoRepository.AddAsync(new ToDoItem
            {
                Title = "Get Sample Working",
                Description = "Try to get the sample to build."
            }));
            tasks.Add(todoRepository.AddAsync(new ToDoItem
            {
                Title = "Review Solution",
                Description = "Review the different projects in the solution and how they relate to one another."
            }));
            tasks.Add(todoRepository.AddAsync(new ToDoItem
            {
                Title = "Run and Review Tests",
                Description = "Make sure all the tests run and review what they are doing."
            }));
            await Task.WhenAll(tasks);
            toDoItems = await todoRepository.ListAsync<ToDoItem>();
            return toDoItems.Count;
        }
    }
}
