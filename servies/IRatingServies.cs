using Entities;

namespace servies
{
    public interface IRatingServies
    {
        Task post(Rating rating);
    }
}