using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        // start test user context member



        // end test user context member

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {

            var userId = User.Identity.GetUserId();

            var exists = _context.Attendances.Any(a => a.AttendeeId == userId && a.Gigid == dto.GigId);
            if (exists)
            {
                return BadRequest("The attendance already exists.");
            }

            var attendance = new Attendance
            {
                Gigid = dto.GigId,
                AttendeeId = userId

            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
