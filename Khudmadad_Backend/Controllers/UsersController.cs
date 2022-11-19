using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Khudmadad_Backend.DbUtils;
using Microsoft.AspNetCore.Mvc;

namespace Khudmadad_Backend.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbUtils _db;

        public UsersController(Ef_DataContext _context)
        {
            _db = new UserDbUtils(_context);
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UsersModel>? data = _db.GetUsers();

                if(data==null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        //GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                UsersModel? data = _db.GetUserById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // GET: api/Users/Create
        [HttpPost("Create")]
        public ActionResult Create(UsersModel user)
        {
            try
            {
                _db.AddUser(user);
                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, user));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
