using Project.Models;

namespace Project.Interface;

public interface IUserRepo
{
    Task<List<ApplicationUser>> GetTutorByKeyWord(string keyWork);
    Task<ApplicationUser?> GetUserById(int id);

    Task<List<ApplicationUser>> GetAllTutors();
}