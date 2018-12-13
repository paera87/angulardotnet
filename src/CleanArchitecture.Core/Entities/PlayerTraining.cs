namespace Hogstorp.Core.Entities
{
    public class PlayerTraining //: BaseEntity
    {
        public int PlayerId { get; set; }
        public int TrainingId { get; set; }
        public Player Player{ get; set; }
        public Training Training{ get; set; }
        public int Points { get; set; }
    }
}
