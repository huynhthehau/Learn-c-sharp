using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon.models;

namespace pokemon.interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
    }
}