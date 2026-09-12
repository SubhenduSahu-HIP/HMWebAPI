using HM_Admin.Models;
using HM_Admin.Repositorys.IRepository;
using HM_Admin.Repositorys.Repository;
using HM_Admin.Services.IService;
using Microsoft.Extensions.Configuration;

namespace HM_Admin.Services.Service
{
    public class AdminUserService: IAdminUserService
    {
        //private readonly HMAdminDBContext _context;
        private readonly IAdminUserRepository _adminUserRepository;
        
        public AdminUserService(IAdminUserRepository adminUserRepository)
        {

            _adminUserRepository = adminUserRepository;
            //_context = dbContext;
        }        

        public Task<AdminUser> CreateAdminUser(AdminUser user)
        {
            
            return _adminUserRepository.CreateAdminUser(user);
        }
    }
}
