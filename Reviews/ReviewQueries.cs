using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using ApiDevInHouse.Characters;
using ApiDevInHouse.Repositories;

namespace ApiDevInHouse.Reviews
{
    /// <summary>
    /// The queries related to reviews.
    /// </summary>
    [ExtendObjectType(OperationTypeNames.Query)]
    public class ReviewQueries
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Review> GetReviews(
            Episode episode,
            [Service]IReviewRepository repository) =>
            repository.GetReviews(episode);
    }
}
