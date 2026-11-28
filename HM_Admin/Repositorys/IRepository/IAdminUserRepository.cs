using HM_Admin.Models;

namespace HM_Admin.Repositorys.IRepository
{
    public interface IAdminUserRepository
    {
        Task<AdminUser> CreateAdminUser(AdminUser user);
        Task<IEnumerable<AdminUser>> GetAllUser();
        Task<IEnumerable<AdminUser>> GetAllAdminUser();
        Task<IEnumerable<AdminUser>> GetUserById(int userId);
        Task<IEnumerable<AdminUser>> GetUserByEmailAndPassword(string email, string password);
        Task<AdminUser> UpdateUser(AdminUser user);

    }
}
