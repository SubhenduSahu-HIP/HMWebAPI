using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
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

        public async Task<IEnumerable<AdminUser>> GetAllUser()
        {
            var users = await _context.AdminUser
                        .AsNoTracking()
                        .Where(u => u.IsDeleted == false)
                        .ToListAsync();

            return users;

        }

        public async Task<IEnumerable<AdminUser>> GetUserByEmailAndPassword(string email, string password)
        {

            try
            {
                var user = await _context.AdminUser
                            .Where(u => u.Email == email && u.Password == password && u.IsDeleted == false)
                            .AsNoTracking()
                            .ToListAsync();
                return user;
            }
            catch (Exception ex)
                        {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<IEnumerable<AdminUser>> GetUserById(int userId)
        {
            try
            {
                var user = await _context.Database.SqlQuery<AdminUser>($"exec dbo.GetUserById @UserID ={userId}").ToListAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<AdminUser?> UpdateUser(AdminUser user)
        {

            try
            {
                var existingUser =
                                     (!string.IsNullOrWhiteSpace(user.Email)
                                      ? await _context.AdminUser.FirstOrDefaultAsync(u => u.Email == user.Email)
                                     : null)
                                        ?? (!string.IsNullOrWhiteSpace(user.Mobile)
                                         ? await _context.AdminUser.FirstOrDefaultAsync(u => u.Mobile == user.Mobile)
                                      : null);

                if (existingUser == null)
                {
                    return null;
                }

                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Mobile = user.Mobile;
                existingUser.Password = user.Password;
                existingUser.Address = user.Address;
                existingUser.Role = user.Role;
                existingUser.Email=user.Email;
                existingUser.IsAdmin = user.IsAdmin;
                existingUser.ModifiedBy = user.ModifiedBy;
                existingUser.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();

                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
