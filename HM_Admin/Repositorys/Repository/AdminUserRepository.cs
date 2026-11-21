using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HM_Admin.Repositorys.Repository
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly HMAdminDBContext _context;
        public AdminUserRepository(HMAdminDBContext dbContext)
        {

            _context = dbContext;
        }
        public async Task<AdminUser> CreateAdminUser(AdminUser newAdminUser)
        {
            try
            {
                await _context.AdminUser.AddAsync(newAdminUser);
                await _context.SaveChangesAsync();
                return newAdminUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<AdminUser>> GetAllAdminUser()
        {
            try
            {
                var users = await _context.AdminUser
                            .Where(u => u.IsAdmin == true && u.IsDeleted == false && u.Role == "Admin").ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AdminUser>> GetUserById(int userId)
        {
            var user = await _context.Database.SqlQuery<AdminUser>($"exec dbo.GetUserById @UserID ={userId}").ToListAsync();


            return user;
        }
    }
}
