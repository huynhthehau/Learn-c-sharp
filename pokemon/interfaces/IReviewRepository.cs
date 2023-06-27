using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon.models;

namespace pokemon.interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewId);
        bool CreateReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool Save();

    }
}