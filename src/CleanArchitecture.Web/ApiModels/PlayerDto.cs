using System.Linq;
using Hogstorp.Core.Entities;

namespace Hogstorp.Web.ApiModels
{
    // Note: doesn't expose events or behavior
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? TotalPoints { get; set; }

        public static PlayerDto FromEntity(Player item)
        {
            return new PlayerDto()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                TotalPoints = item.PlayerTrainings?.Sum(x => x.Points) ?? 0
            };
        }

        public static Player ToEntity(PlayerDto item)
        {
            return new Player()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
            };
        }
    }
}
