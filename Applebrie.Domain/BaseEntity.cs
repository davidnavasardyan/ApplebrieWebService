namespace Applebrie.Domain
{
    public class BaseEntity
    {
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
    }
}
