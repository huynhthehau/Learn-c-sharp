using learn_specification.Entities;

namespace learn_specification.Models.PostModel
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string PostContents { get; set; }
        public List<PostTags> PostTags { get; set; }
        public List<PostCategories> PostCategories { get; set; }
        public List<Comment> Comments { get; set; }
    }
}