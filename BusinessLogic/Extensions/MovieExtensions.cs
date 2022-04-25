namespace BusinessLogic.Extensions
{
    public static class MovieExtensions
    {
        public static DTO.Movie ToDTO(this DomainModels.Movie movie)
        {
            return new DTO.Movie()
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre,
                UserId = movie.UserId,
            };
        } 
    }
}
