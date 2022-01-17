using Microsoft.AspNetCore.Mvc;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Infrastructure.EF.InputModels;
using System;
using TakeYourTicket.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TakeYourTicket.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class SessionController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ILogger<SessionController> _logger;

        public SessionController(ISessionRepository sessionRepository, ILogger<SessionController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SearchByMovieIdAndDate([FromQuery] SearchByMovieIdAndDateInputModel queryParams)
        {
            if (!Guid.TryParse(queryParams.MovieId, out var movieId))
            {
                return BadRequest("Invalid Id");
            }

            List<Session> sessions = _sessionRepository.FindByMovieIdAndDay(movieId, queryParams.Date).ToList();
            _logger.LogInformation("Session list found for {movieId} with {countItems} items", movieId, sessions.Count);

            return Ok(sessions);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSessionInputModel session)
        {
            if (!Guid.TryParse(session.MovieId, out var movieId))
            {
                return BadRequest("Invalid Id");
            }

            Session newSession = new Session(session.ExhibitionDate, session.NumberOfSeats, session.Price, movieId);

            Session createdSession = await _sessionRepository.Create(newSession);
            _logger.LogInformation("Session created with id {sessionId}", createdSession.Id);

            return Ok(createdSession);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateSessionInputModel updateSession)
        {
            if (!Guid.TryParse(id, out var sessionId))
            {
                return BadRequest("Invalid Id");
            }

            Guid movieId = Guid.Empty;

            if (updateSession.MovieId != null)
            {
                if (!Guid.TryParse(updateSession.MovieId, out movieId))
                {
                    return BadRequest("Invalid movie Id");
                }
            }


            if (updateSession == null)
            {
                return BadRequest();
            }

            Session toUpdateSession = new Session(updateSession.ExhibitionDate, updateSession.NumberOfSeats, updateSession.Price, movieId);

            Session updatedSession = await _sessionRepository.Update(toUpdateSession, sessionId);
            _logger.LogInformation("Session created with id {sessionId}", updatedSession.Id);

            return Ok(updatedSession);

        }
    }
}
