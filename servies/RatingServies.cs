using Entities;
using repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class RatingServies : IRatingServies
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingServies(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task post(Rating rating){
            await _ratingRepository.post(rating);
        }
    }
}
