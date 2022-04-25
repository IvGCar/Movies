namespace DataAccess.Extensions
{
    public static class MovieExtensions
    {
        public static BusinessLogic.DomainModels.Movie ToDomainModel(this Models.Movie movie)
        {
            return new BusinessLogic.DomainModels.Movie
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Name = movie.Name,
                UserId = movie.UserId,
            };
        }
    }
}
