using Khudmadad_Backend.DbUtils;
using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Khudmadad_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleDbUtils _db;

        public RoleController(Ef_DataContext _context)
        {
            _db = new RoleDbUtils(_context);
        }

        // GET: api/roles
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<RolesModel>? data = _db.GetRoles();

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

        // GET: api/roles/Create
        [HttpPost("Create")]
        public ActionResult Create(RolesModel role)
        {
            try
            {
                _db.AddRole(role);
                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, role));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
