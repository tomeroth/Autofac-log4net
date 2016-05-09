using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication9.Interfaces;
using WebApplication9.Models;
using WebApplication9.Services;

namespace WebApplication9.Controllers
{
    public class PaintingsController : ApiController
    {
        private readonly IPaintingsRepository _pr;
        private readonly ILogger _logger;

        public PaintingsController(IPaintingsRepository pr, ILogger logger)
        {
            _pr = pr;
            _logger = logger;
        }

        public IEnumerable<Painting> GetPaintings()
        {
            _logger.Write("Get all Paintings was called", LogLevel.INFO);
            return _pr.GetAll();
        }

        public IHttpActionResult GetPainting(int id)
        {
            _logger.Write("Get Painting was called", LogLevel.INFO);
            Painting painting = _pr.Get(id);
            if (painting == null)
            {
                return NotFound();
            }

            return Ok(painting);
        }

        [ResponseType(typeof(Painting))]
        public IHttpActionResult PutPainting(int id, Painting painting)
        {
            _logger.Write("Put Painting was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != painting.Id)
            {
                return BadRequest();
            }

            Painting p = _pr.Update(painting);
            if (p == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [ResponseType(typeof(Painting))]
        public IHttpActionResult PostPainting(Painting painting)
        {
            _logger.Write("Post Painting was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pr.Add(painting);

            return Ok(painting.Id);
        }

        public IHttpActionResult DeletePainting(int id)
        {
            _logger.Write("Delete Painting was called", LogLevel.INFO);
            if (!_pr.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
