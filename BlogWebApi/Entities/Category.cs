namespace learn_specification.Entities;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public List<Post> AssociatedPosts { get; set; }
}