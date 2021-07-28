namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
