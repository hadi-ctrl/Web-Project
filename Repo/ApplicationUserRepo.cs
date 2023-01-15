using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interface;
using Project.Models;

namespace Project.Repo;

public class ApplicationUserRepo : IUserRepo
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserRepo(ApplicationDbContext db, UserManager<ApplicationUser> _userManager)
    {
        _db = db;
        this._userManager = _userManager;
    }

    public async Task<List<ApplicationUser>> GetTutorByKeyWord(string keyWork)
    {
        var tutors = await _db.Members.Where(t => t.Major != null && t.Major.Contains(keyWork)).ToListAsync();

        if (tutors == null)
        {
            return new List<ApplicationUser>();
        }

        return tutors;
    }

    public async Task<ApplicationUser?> GetUserById(int id)
    {
        var user = await _db.Members.FirstOrDefaultAsync(t => t.Id.Equals(id.ToString()));

        if (user == null)
        {
            return new ApplicationUser();
        }
        

        return user;
    }

    public async Task<List<ApplicationUser>> GetAllTutors()
    {

        var tutors = await _db.Members.Where(t => t.UserType.Equals("Tutor")).ToListAsync();

        

        return tutors;

    }
}