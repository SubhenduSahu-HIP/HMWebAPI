using HM_Admin.Models;

namespace HM_Admin.Repositorys.IRepository
{
    public interface IAdminUserRepository
    {
        Task<AdminUser> CreateAdminUser(AdminUser user);
        Task<IEnumerable<AdminUser>> GetAllUser();
    }
}
