using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Khudmadad_Backend.DbUtils;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

        //GET: api/Users/userid/{id}
        [HttpGet("userid/{id}")]
        public ActionResult GetUserById(int id)
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

        //GET: api/Users/username/{userName}
        [HttpGet("username/{userName}")]
        public ActionResult GetUserByUsername(string userName)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                UsersModel? data = _db.GetUserByUsername(userName);
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

        // GET: api/Users/create
        [HttpPost("create")]
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

        [HttpPut("update")]
        public ApiResponse UpdateUser(UsersModel user)
        {
            try
            {
                var _u = _db.UpdateUser(user);
                if (_u)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _u);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _u);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        [HttpDelete("delete")]
        public ApiResponse DeleteOffer(UsersModel user)
        {
            try
            {
                var _u = _db.DeleteUser(user);
                if (_u)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _u);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _u);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

    }
}
