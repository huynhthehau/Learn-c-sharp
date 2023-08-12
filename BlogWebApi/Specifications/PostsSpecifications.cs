using learn_specification.Entities;

namespace learn_specification.Specifications
{
    public class PostRelatedDataSpecifications : BaseSpecifications<Post>
    {
        public PostRelatedDataSpecifications() : base()
        {
            AddInclude(post => post.PostTags);
            AddInclude(post => post.PostCategories);
            AddInclude(post => post.Comments);
        }
    }
}