using LinBeach.Data;
using Microsoft.EntityFrameworkCore;

namespace LinBeach.Repositories
{
    public interface IUserRep
    {
        Task<IEnumerable<ApplicationUser>> GetAll();
        Task<bool> Add(ApplicationUser user, string password, List<string> roles);
        Task Delete(Guid id);
        Task<bool> UserNameExists(string username);
        Task<bool> EmailExists(string email);


    }
}
