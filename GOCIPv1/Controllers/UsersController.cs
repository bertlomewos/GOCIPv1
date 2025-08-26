using GOCIPv1.Data;
using GOCIPv1.Model;
using GOCIPv1.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GOCIPv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GOCIPDbContext _context;
        public UsersController(GOCIPDbContext context)
        {
            _context = context;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        // GET: api/Users/{id}
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserDto user)
        {
            if (user == null)
                return BadRequest("User data is required");
            var newUser = new User
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                ProfilePictureUrl = user.ProfilePictureUrl,
                UserName = user.UserName,
                Age = user.Age,
                Gender = user.Gender,
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { userId = newUser.Id }, newUser);
        }
        // PUT: api/Users/{id}
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, UserDto user)
        {

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (existingUser == null)
                return NotFound();
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.ProfilePictureUrl = user.ProfilePictureUrl;
            existingUser.UserName = user.UserName;
            existingUser.Age = user.Age;
            existingUser.Gender = user.Gender;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE: api/Users/{id}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
