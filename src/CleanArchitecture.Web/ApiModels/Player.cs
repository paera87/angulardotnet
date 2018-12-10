using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Web.ApiModels
{
    // Note: doesn't expose events or behavior
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        public static PlayerDto FromToDoItem(Player item)
        {
            return new PlayerDto()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
            };
        }
    }
}
