using Entities;

namespace repository
{
    public interface IRatingRepository
    {
        Task post(Rating rating);
    }
}