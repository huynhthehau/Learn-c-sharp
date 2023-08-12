namespace learn_specification.Entities;
public class BaseEntity
{
    public int Id { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public DateTime PublishedOn { get; set; }
}