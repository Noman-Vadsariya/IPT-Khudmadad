using Khudmadad_Backend.DbUtils;
using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Khudmadad_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigController : ControllerBase
    {
        private readonly GigDbUtils _db;

        public GigController(Ef_DataContext _context)
        {
            _db = new GigDbUtils(_context);
        }

        // GET: api/Gigs
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<GigModel>? data = _db.GetGigs();

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        //GET: api/Gigs/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                GigModel? data = _db.GetGigById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // GET: api/Gigs/Create
        [HttpPost("Create")]
        public ActionResult Create(GigModel gig)
        {
            try
            {
                _db.AddGig(gig);
                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, gig));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
