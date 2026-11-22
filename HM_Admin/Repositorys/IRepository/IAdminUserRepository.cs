using HM_Admin.Models;

namespace HM_Admin.Repositorys.IRepository
{
    public interface IAdminUserRepository
    {
        Task<IEnumerable<AdminUser>> GetAllUser();
        Task<AdminUser> CreateAdminUser(AdminUser user);
        Task<IEnumerable<AdminUser>> GetAllAdminUser();
        Task<IEnumerable<AdminUser>> GetUserById(int userId);
    }
}
