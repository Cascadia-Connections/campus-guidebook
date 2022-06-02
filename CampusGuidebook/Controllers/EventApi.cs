using CampusGuidebook.Data;
using Microsoft.AspNetCore.Mvc;
using CampusGuidebook.Models;
using Microsoft.AspNetCore.Identity;


namespace CampusGuidebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventApi : ControllerBase
    {
        public AppDbContext Adbc;
        public AppIdentityDbContext AIdbc;
        public EventApi(AppDbContext DBC_, AppIdentityDbContext AIDbc) { Adbc = DBC_; AIDbc = AIdbc; }

        [HttpGet] public IActionResult GetEvents() { return Ok(Adbc.EventTable); }
        [HttpGet] public IActionResult GetUsers() { return Ok(AIdbc.Users); }
        [HttpGet] public IActionResult GetRoles() { return Ok(AIdbc.Roles); }

        [HttpGet("{id}")] public IActionResult GetEvent(int ID) {
            var passin = Adbc.EventTable.Where(c => c.id == ID);
            if (!passin.Any()) return NotFound();
            return Ok(passin);
        }
        [HttpGet("{id}")] public IActionResult GetUser(string ID) {
            var passin = AIdbc.Users.Where(c => c.Id == ID);
            if (!passin.Any()) return NotFound();
            return Ok();
        }
        

        [HttpGet("{id}")]
        public IActionResult GetStatus(int ID)
        {
            EventsModel passin = Adbc.EventTable.Where(c => c.id == ID).FirstOrDefault();

            switch (passin.UploadStatus) {
                case 0: return Ok("Pending"); break;
                case 1: return Ok("Approve"); break;
                case 2: return Ok("Denied"); break;
            }
            return NotFound("Could not find status in ");
        }
        [HttpGet("{id}")]
        public IActionResult GetAcceptedEvents() { 
        return Ok(Adbc.EventTable.Where(u => u.UploadStatus == 1));
        }

        [HttpPost]
        public IActionResult PostUser(IdentityUser ImputUser) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            AIdbc.Users.Add(ImputUser);
            AIdbc.SaveChanges();
            return Ok("Added");
        }

        [HttpPost]
        public IActionResult PostRole(IdentityRole ImputRole)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            AIdbc.Roles.Add(ImputRole);
            AIdbc.SaveChanges();
            return Ok("Added");
        }

        [HttpPost]
        public IActionResult PostEvent([FromBody] EventsModel ImputEvent)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            Adbc.Add(ImputEvent);
            Adbc.SaveChanges();
            return Ok("added");
        }

        [HttpPost]
        public IActionResult PostObject(Object InputUnknown)
        { // Add more post methods when needed
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (InputUnknown.GetType() == typeof(EventsModel)) {
                Adbc.EventTable.Add((EventsModel)InputUnknown);
            } else {
                return BadRequest("Did not provide valid model");
            }
            Adbc.SaveChanges();
            return Ok("Added");
        }

        [HttpPut("{id}")]
        public IActionResult PutObject(Object InputObject)
        { // add more update methods when needed
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (InputObject.GetType() == typeof(EventsModel)) {
                Adbc.EventTable.Update((EventsModel)InputObject);
            } else {
                return BadRequest("Not a valid model");
            }
            return Accepted("Updated");
        }

        [HttpPut("{id}")]
        public IActionResult putIdentityObject(Object ImputObject) {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (ImputObject.GetType() == typeof(IdentityRole)) {
                AIdbc.Roles.Update((IdentityRole)ImputObject);
            } else if (ImputObject.GetType() == typeof(IdentityUser)) {
                AIdbc.Users.Update((IdentityUser)ImputObject);
            } else {
                return BadRequest("Not a valid model");
            }
            return Accepted("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int ID)
        {
            if (!Adbc.EventTable.Where(u => u.id == ID).Any()) { return BadRequest("Not a valid ID. Likely out of bounds"); }
            var DeleteingThis = Adbc.EventTable.Where(u => u.id == ID).FirstOrDefault();
            Adbc.EventTable.Remove(DeleteingThis);
            Adbc.SaveChanges();
            return Accepted("Deleted");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string ID) {
            IdentityUser user = AIdbc.Users.Where(h => h.Id == ID).FirstOrDefault();
            AIdbc.Remove(user);
            AIdbc.SaveChanges();
            return Ok(user);
        }
        public IActionResult DeleteRole(string ID) {
            IdentityRole user = AIdbc.Roles.Where(h => h.Id == ID).FirstOrDefault();
            AIdbc.Remove(user);
            AIdbc.SaveChanges();
            return Ok(user);
        }
    }
}
