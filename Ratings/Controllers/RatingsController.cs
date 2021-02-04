using Microsoft.AspNetCore.Mvc;
using Ratings.Infra;
using Ratings.Models;
using Ratings.Repositories.Ratings;
using System;
using System.Linq;

namespace Ratings.Controllers
{
    [ApiController]
    [Route("userRatings")]

    public class RatingsController : ControllerBase
    {
        private IRatingRepository _repository;

        public RatingsController(IRatingRepository repository)
        {
            _repository = repository;
            // renomear para _ratingRepository para evitar confusão
        }

        [HttpGet("{userId}/{getHistory?}")]
        public IActionResult GetById(int userId, int? getHistory)
        {
            try
            {
                // não era melhor getHistory ser um bool?
                if (getHistory != 0 && getHistory != 1 && getHistory != null)
                {
                    throw new ArgumentException("Parâmetro inválido para obtenção de histórico.");
                }

                var ratings = _repository.GetById(userId);

                bool isToProvideHistory = getHistory == 1;
                var mostRecentRating = ratings
                    .OrderByDescending(r => r.ReviewDate)
                    .LastOrDefault(); // como não tá ordenado, nada garante que você tá pegando realmente o que você quer aqui

                if (mostRecentRating == null)
                {
                    return NotFound(new ErrorActionResult(404, "Não há nenhuma avaliação.")); 
                    // 404 Not Found significa que não achou o método
                    // NotContent é mais apropriado

                }

                if (isToProvideHistory)
                {
                    return Ok(new SuccessActionResult<object>(new
                    {
                        lastReview = mostRecentRating,
                        history = ratings
                    }));
                }

                return Ok(new SuccessActionResult<object>(new { lastReview = mostRecentRating }));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new ErrorActionResult(400, exception.Message));
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ErrorActionResult(500, exception.Message));
            }
        }

        [HttpPost]
        public ActionResult<Rating> Create([FromBody] CreateRatingDTO createRatingDTO)
        {
            if (createRatingDTO == null)
            {
                throw new ArgumentNullException(nameof(createRatingDTO));
            }

            try
            {
                var rating = new Rating
                (
                    createRatingDTO.UserId,
                    createRatingDTO.Mood,
                    createRatingDTO.Platform,
                    createRatingDTO.AppVersion,
                    createRatingDTO.Feedback
                );

                _repository.Create(rating);

                var readRatingDTO = new ReadRatingDTO
                (
                    rating.UserId,
                    rating.Mood,
                    rating.Platform,
                    rating.AppVersion,
                    rating.Feedback,
                    rating.ReviewDate
                );

                return Ok(new SuccessActionResult<ReadRatingDTO>(readRatingDTO));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new ErrorActionResult(400, exception.Message));
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ErrorActionResult(500, exception.Message));
            }

        }
    }
}
