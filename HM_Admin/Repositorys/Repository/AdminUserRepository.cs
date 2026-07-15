using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<AdminUser>> GetAllUser()
        {
            try
            {
                return await _context.AdminUser.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
