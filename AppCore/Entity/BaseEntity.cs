namespace AppCore.Entity
{
    public class BaseEntity : Audit, ISoftDeleted
    {
        public bool IsDeleted { get; set; } = false;
    }
}
