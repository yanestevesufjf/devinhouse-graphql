using System.Collections.Generic;
using ApiDevInHouse.Characters;
using ApiDevInHouse.Reviews;

namespace ApiDevInHouse.Repositories
{
    public interface IReviewRepository
    {
        void AddReview(Episode episode, Review review);
        IEnumerable<Review> GetReviews(Episode episode);
    }
}
