using HM_Admin.Models;

namespace HM_Admin.Services.IService
{
    public interface IAdminUserService
    {
        public Task<AdminUser> CreateAdminUser(AdminUser user);
    }
}
