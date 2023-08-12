using System.Linq.Expressions;
using learn_specification.Entities;

namespace learn_specification.Specifications
{
    public class AndSpecification<T> : BaseSpecifications<T>
    {
        private readonly BaseSpecifications<T> _left;
        private readonly BaseSpecifications<T> _right;

        public AndSpecification(BaseSpecifications<T> left, BaseSpecifications<T> right)
        {
            _right = right;
            _left = left;
        }

        // Overriden virtual property
        public override Expression<Func<T, bool>> FilterCondition => this.GetFilterExpression();

        public Expression<Func<T, bool>> GetFilterExpression()
        {
            var leftExpression = _left.FilterCondition;
            var rightExpression = _right.FilterCondition;

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
    // OrSpepcification.cs
    public class OrSpecification<T> : BaseSpecifications<T>
    {
        private readonly BaseSpecifications<T> _left;
        private readonly BaseSpecifications<T> _right;

        public OrSpecification(BaseSpecifications<T> left, BaseSpecifications<T> right)
        {
            _right = right;
            _left = left;
        }

        // Overriden virtual property
        public override Expression<Func<T, bool>> FilterCondition => this.GetFilterExpression();

        public Expression<Func<T, bool>> GetFilterExpression()
        {
            var leftExpression = _left.FilterCondition;
            var rightExpression = _right.FilterCondition;

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            return Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);
        }
    }

    // ParameterReplacer.cs
    // To avoid exception which occurs if parameters are not replaced properly
    public class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);

        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
    }
    public class PostByIdSpepcification : BaseSpecifications<Post>
    {
        public PostByIdSpepcification(int id) : base()
        {
            SetFilterCondition(post => post.Id == id);
        }
    }

    public class PostsWithoutCommentsSpecification : BaseSpecifications<Post>
    {
        public PostsWithoutCommentsSpecification() : base()
        {
            SetFilterCondition(post => post.Comments.Count == 0);
        }
    }

    public class PostsCreatedInLastMonthSpecification : BaseSpecifications<Post>
    {
        public PostsCreatedInLastMonthSpecification() : base()
        {
            SetFilterCondition(post => post.CreatedOn >= DateTime.Now.AddMonths(-1));
        }
    }
}