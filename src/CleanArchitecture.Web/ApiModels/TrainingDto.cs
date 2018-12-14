using System;
using System.Linq;
using Hogstorp.Core.Entities;

namespace Hogstorp.Web.ApiModels
{
    // Note: doesn't expose events or behavior
    public class TrainingDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public int? NumberOfPlayersPresent { get; set; }
        public bool Indoors { get; set; }
        
        public static TrainingDto FromToDoItem(Training item)
        {
            return new TrainingDto()
            {
                Id = item.Id,
                Location = item.Location,
                Date = item.Date.ToString("yyyy-MM-dd"),
                NumberOfPlayersPresent = item.PlayersTrainings?.Count ?? 0,
                Indoors = item.Indoors
            };
        }

     
    }
}
