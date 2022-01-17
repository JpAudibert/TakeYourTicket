using Microsoft.AspNetCore.Mvc;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Infrastructure.EF.InputModels;
using System;
using TakeYourTicket.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeYourTicket.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class SessionController : Controller
    {
        private ISessionRepository _sessionRepository;

        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet]
        public IActionResult SearchByMovieIdAndDate([FromQuery] SearchByMovieIdAndDateInputModel queryParams)
        {
            try
            {
                if (!Guid.TryParse(queryParams.MovieId, out var movieId))
                {
                    return BadRequest("Invalid Id");
                }

                List<Session> sessions = _sessionRepository.FindByMovieIdAndDay(movieId, queryParams.Date).ToList();

                return Ok(sessions);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSessionInputModel session)
        {
            try
            {
                if (!Guid.TryParse(session.MovieId, out var movieId))
                {
                    return BadRequest("Invalid Id");
                }

                Session newSession = new Session(session.ExhibitionDate, session.NumberOfSeats, session.Price, movieId);

                Session createdSession = await _sessionRepository.Create(newSession);

                return Ok(createdSession);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateSessionInputModel updateSession)
        {
            try
            {
                if (!Guid.TryParse(id, out var sessionId))
                {
                    return BadRequest("Invalid Id");
                }

                Guid movieId = Guid.Empty;

                if(updateSession.MovieId != null)
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

                return Ok(updatedSession);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
