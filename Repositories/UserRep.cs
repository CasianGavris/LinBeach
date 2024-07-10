using LinBeach.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LinBeach.Repositories
{
    public class UserRep : IUserRep
    {
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRep(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager)
        {
            this.authDbContext = authDbContext;
            this.userManager = userManager;
        }

        public async Task<bool> Add(ApplicationUser user, string password, List<string> roles)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                result = await userManager.AddToRolesAsync(user, roles);
                if (result.Succeeded)
                {
                    return true;
                }
                
            }
            return false;
        }

        public async Task Delete(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            var users = await authDbContext.Users.ToListAsync();
            var superAdmin = await authDbContext.Users.FirstOrDefaultAsync(x => x.UserName == "superadmin");
            if(superAdmin != null)
            {
                users.Remove(superAdmin);
            }
            return users;
        }
        public async Task<bool> UserNameExists(string username)
        {
            var userE = await authDbContext.Users.FirstOrDefaultAsync(x => x.UserName ==  username);
            if (userE != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> EmailExists(string email)
        {
            var userE = await authDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (userE != null)
            {
                return true;
            }
            return false;
        }

    }
}
